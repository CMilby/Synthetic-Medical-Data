using System;

namespace MedicalDataGeneration.DecisionGraphs {

	public enum eTransitionComparisons {
		COMPARE_DISORDERS,
		COMPARE_AGE,
		COMPARE_VARIABLES,
		COMPARE_BLOOD_PRESSURE,
		COMPARE_RISK_FACTORS_SMOKE,
		COMPARE_RISK_FACTORS_DRINK,
		COMPARE_GENDER,
		COMPARE_PREGNANT,
		COMPARE_NONE
	}

	public class Transition : IComparable {

		private int Index;
		private int To;
		// -1 == deny, -2 == approve, -3 Consult

		private eTransitionComparisons Comparisons;
		private string Conditions;

		public Transition( int p_index, int p_to, eTransitionComparisons p_compare, string p_conditions ) {
			Index = p_index;
			To = p_to;
			Comparisons = p_compare;
			Conditions = p_conditions.Replace ( "&lt;", "<" ).Replace ( "&gt;", ">" ).ToLower ( );
		}

		public int GetIndex() {
			return Index;
		}

		public int GetTo() {
			return To;
		}

		public eTransitionComparisons GetComparator() {
			return Comparisons;
		}

		/*public bool Comparator( Person p_person ) {
			switch ( Comparisons ) {
				case eTransitionComparisons.COMPARE_AGE:
					return CompareAge ( p_person, Conditions );
				case eTransitionComparisons.COMPARE_DISORDERS:
					return CompareDisorder ( p_person, Conditions );
				case eTransitionComparisons.COMPARE_VARIABLES:
					return CompareVariables ( );
				case eTransitionComparisons.COMPARE_GENDER:
					return CompareGender ( p_person );
				case eTransitionComparisons.COMPARE_RISK_FACTORS_DRINK:
					return CompareRiskFactorDrinking ( p_person );
				case eTransitionComparisons.COMPARE_RISK_FACTORS_SMOKE:
					return CompareRiskFactorSmoking ( p_person );
				case eTransitionComparisons.COMPARE_BLOOD_PRESSURE:
					return CompareBloodPressure ( p_person );
				case eTransitionComparisons.COMPARE_PREGNANT:
					return ComparePregnant ( p_person );
				default:
					return false;
			}
		}*/

		public static eTransitionComparisons StringToTransitionComparison( string p_value ) {
			switch ( p_value ) {
				case "age":
					return eTransitionComparisons.COMPARE_AGE;
				case "disorders":
				case "disorder":
					return eTransitionComparisons.COMPARE_DISORDERS;
				case "variables":
				case "variable":
					return eTransitionComparisons.COMPARE_VARIABLES;
				case "gender":
				case "sex:":
					return eTransitionComparisons.COMPARE_GENDER;
				case "blood_pressure":
					return eTransitionComparisons.COMPARE_BLOOD_PRESSURE;
				case "risk_factors.smoke":
					return eTransitionComparisons.COMPARE_RISK_FACTORS_SMOKE;
				case "risk_factors.drink":
					return eTransitionComparisons.COMPARE_RISK_FACTORS_DRINK;
				case "pregnant":
					return eTransitionComparisons.COMPARE_PREGNANT;
				default:
					return eTransitionComparisons.COMPARE_NONE;
			}
		}

		private bool ComparePregnant( Person p_person ) {
			return false;
		}

		private bool CompareBloodPressure( Person p_person ) {
			return false;
		}

		private bool CompareRiskFactorSmoking( Person p_person ) {
			return false;
		}

		private bool CompareRiskFactorDrinking( Person p_person ) {
			return false;
		}

		private bool CompareGender( Person p_person ) {
			return false;
		}

		private bool CompareAge( Person p_person, string p_condition ) {
			if ( p_condition.Contains ( "and" ) ) {
				string cond1 = p_condition.Substring ( 0, p_condition.IndexOf ( "and" ) );
				string cond2 = p_condition.Substring ( p_condition.IndexOf ( "and" ) + 3 );
				return CompareAge ( p_person, cond1 ) && CompareAge ( p_person, cond2 );
			} else {
				if ( p_condition.Contains ( ">=" ) ) {
					return p_person.GetAge ( ) >= int.Parse ( p_condition.Replace ( ">=", "" ) );
				} else if ( p_condition.Contains ( "<=" ) ) {
					return p_person.GetAge ( ) <= int.Parse ( p_condition.Replace ( "<=", "" ) );
				} else if ( p_condition.Contains ( "<" ) ) {
					return p_person.GetAge ( ) < int.Parse ( p_condition.Replace ( "<", "" ) );
				} else if ( p_condition.Contains ( ">" ) ) {
					return p_person.GetAge ( ) > int.Parse ( p_condition.Replace ( ">", "" ) );
				} else if ( p_condition.Contains ( "==" ) ) {
					return p_person.GetAge ( ) == int.Parse ( p_condition.Replace ( "==", "" ) );
				}
			}

			return false;
		}

		private bool CompareDisorder( Person p_person, string p_condition ) {
			if ( p_condition.Equals ( "Other" ) ) {
				return true;
			}

			return p_person.HasDisorder ( p_condition );
		}

		private bool CompareVariables() {
			return true;
		}

		public void CreatePregnantFromCondition ( ref Person p_person ) {
			p_person.Sex = eSex.FEMALE;
			p_person.MedData.IsPregnant = Conditions.Equals ( "true" ) ? true : false;
		}

		public void CreateBloodPressureFromCondition( ref Person p_person, Random p_random ) {
			if ( Conditions.Equals ( "high" ) ) {
				p_person.GiveHighBloodPressure ( p_random );
			} else if ( Conditions.Equals ( "normal" ) ) {
				p_person.GiveNormalBloodPressure ( p_random );
			} else if ( Conditions.Equals ( "low" ) ) {
				p_person.GiveLowBloodPressure ( p_random );
			} else {
				p_person.GiveNormalBloodPressure ( p_random );
			}
		}

		public void CreateRiskFactorSmokeFromCondition( ref Person p_person ) {
			if ( Conditions.Equals ( "high" ) ) {
				p_person.AddRiskFactor ( eRiskFactor.HEAVY_SMOKER );
			} else if ( Conditions.Equals ( "moderate" ) ) {
				p_person.AddRiskFactor ( eRiskFactor.MODERATE_SMOKER );
			} else if ( Conditions.Equals ( "low" ) ) {
				p_person.AddRiskFactor ( eRiskFactor.LIGHT_SMOKER );
			} else {
				p_person.AddRiskFactor ( eRiskFactor.NON_SMOKER );
			}
		}

		public void CreateRiskFactorDrinkFromCondition( ref Person p_person ) {
			if ( Conditions.Equals ( "high" ) ) {
				p_person.AddRiskFactor ( eRiskFactor.HEAVY_DRINKER );
			} else if ( Conditions.Equals ( "moderate" ) ) {
				p_person.AddRiskFactor ( eRiskFactor.MODERATE_DRINKER );
			} else if ( Conditions.Equals ( "low" ) ) {
				p_person.AddRiskFactor ( eRiskFactor.LIGHT_DRINKER );
			} else {
				p_person.AddRiskFactor ( eRiskFactor.NON_DRINKER );
			}
		}

		public void CreateGenderFromCondition( ref Person p_person ) {
			if ( Conditions.Equals ( "male" ) ) {
				p_person.Sex = eSex.MALE;
			} else if ( Conditions.Equals ( "female" ) ) {
				p_person.Sex = eSex.FEMALE;
			}
		}

		public void CreateAgeFromConditions( ref Person p_person, Random p_random, bool p_inRange = true ) {
			if ( Conditions.Contains ( "and" ) ) {
				string cond1 = Conditions.Substring ( 0, Conditions.IndexOf ( "and" ) );
				string cond2 = Conditions.Substring ( Conditions.IndexOf ( "and" ) + 3 );

				int val0 = -1;
				int val1 = -1;

				if ( cond1.Contains ( ">=" ) ) {
					val0 = int.Parse ( cond1.Replace ( ">=", "" ) );
				} else if ( cond1.Contains ( ">" ) ) {
					val0 = int.Parse ( cond1.Replace ( ">", "" ) );
				}

				if ( cond2.Contains ( "<=" ) ) {
					val1 = int.Parse ( cond2.Replace ( "<=", "" ) );
				} else if ( cond2.Contains ( "<" ) ) {
					val1 = int.Parse ( cond2.Replace ( "<", "" ) );
				}

				if ( val0 > val1 ) {
					p_person.CreateDateOfBirthOutOfRange ( p_random, val1, val0 );
				} else if ( val0 < val1 ) {
					p_person.CreateDateOfBirthInRange ( p_random, val0, val1 );
				} else {
					throw new NotImplementedException ( "Error: Age equal to not implemented" );
				}
			} else {
				int value = -1;
				if ( Conditions.Contains ( ">=" ) ) {
					value = int.Parse ( Conditions.Replace ( ">=", "" ) );
					if ( p_inRange ) {
						p_person.CreateDateOfBirthGreaterThanAge ( p_random, value );
					} else {
						p_person.CreateDateOfBirthLessThanAge ( p_random, value - 1 );
					}
				} else if ( Conditions.Contains ( "<=" ) ) {
					value = int.Parse ( Conditions.Replace ( "<=", "" ) );
					if ( p_inRange ) {
						p_person.CreateDateOfBirthLessThanAge ( p_random, value );
					} else {
						p_person.CreateDateOfBirthGreaterThanAge ( p_random, value + 1 );
					}
				} else if ( Conditions.Contains ( ">" ) ) {
					value = int.Parse ( Conditions.Replace ( ">", "" ) );
					if ( p_inRange ) {
						p_person.CreateDateOfBirthGreaterThanAge ( p_random, value + 1 );
					} else {
						p_person.CreateDateOfBirthLessThanAge ( p_random, value );
					}
				} else if ( Conditions.Contains ( "<" ) ) {
					value = int.Parse ( Conditions.Replace ( "<", "" ) );
					if ( p_inRange ) {
						p_person.CreateDateOfBirthLessThanAge ( p_random, value - 1 );
					} else {
						p_person.CreateDateOfBirthGreaterThanAge ( p_random, value );
					}
				} else if ( Conditions.Contains ( "==" ) ) {
					throw new NotImplementedException ( "Error: Age equal to not implemented" );
				}
			}
		}

		public void CreateDisordersFromConditions( ref Person p_person ) {
			p_person.AddDisorder ( Conditions );
		}

		public int CompareTo( object p_obj ) {
			if ( p_obj == null ) {
				return 1;
			}

			Transition trans = p_obj as Transition;
			if ( trans != null ) {
				return Index.CompareTo ( trans.Index );
			} else {
				throw new ArgumentException ( "Object is not a Transition" );
			}
		}
	}
}

