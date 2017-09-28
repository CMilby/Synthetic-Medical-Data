using System;
using System.Collections;
using System.Collections.Generic;

namespace MedicalDataGeneration {

	public enum eRiskFactor {
		HEAVY_DRINKER,
		MODERATE_DRINKER,
		LIGHT_DRINKER,
		HEAVY_SMOKER,
		MODERATE_SMOKER,
		LIGHT_SMOKER
	}

	public class MedicalData {

		public List<eRiskFactor> RiskFactors;

		public int Systolic;
		public int Diastolic;

		public List<string> Disorders;

		public MedicalData ( Person p_person, Random p_random, params eRiskFactor[] p_riskFactors ) {
			RiskFactors = new List<eRiskFactor> ( p_riskFactors );
			GenerateBloodPressure ( p_person, RiskFactors, p_random, out Systolic, out Diastolic );

			Disorders = new List<string> ( );
		}

		public MedicalData ( int p_systolic, int p_diastolic ) {
			RiskFactors = new List<eRiskFactor> ( );

			Systolic = p_systolic;
			Diastolic = p_diastolic;

			Disorders = new List<string> ( );
		}

		public MedicalData ( Random p_random, Person p_person, List<string> p_disorders ) {
			RiskFactors = new List<eRiskFactor> ( );
			GenerateBloodPressure ( p_person, new List<eRiskFactor> ( ), p_random, out Systolic, out Diastolic );

			Disorders = p_disorders;
		}

		public override string ToString ( ) {
			string ret = "Blood Pressure: " + Systolic.ToString ( ) + "/" + Diastolic.ToString ( ) + "\n";
			for ( int i = 0; i < RiskFactors.Count; i++ ) {
				ret += RiskFactors [ i ] + "|";
			}
			ret = ret.Substring ( 0, ret.Length - 2 );
			return ret;
		}

		public string ToCSV ( ) {
			string ret = Systolic.ToString ( ) + "," + Diastolic.ToString ( ) + ",";
			for ( int i = 0; i < RiskFactors.Count; i++ ) {
				ret += RiskFactors [ i ] + "|";
			}
			if ( ret.EndsWith ( "|" ) ) {
				ret = ret.Substring ( 0, ret.Length - 1 );
			}
			for ( int i = 0; i < Disorders.Count; i++ ) {
				ret += Disorders [ i ] + "|";
			}
			if ( ret.EndsWith ( "|" ) ) {
				ret = ret.Substring ( 0, ret.Length - 1 );
			}
			return ret; 
		}

		public bool HasDisorder ( string p_disorder ) {
			return Disorders.Contains ( p_disorder );
		}

		public static MedicalData GenerateMedicalData ( Person p_person, Random p_random, params eRiskFactor[] p_riskFactors ) {
			return new MedicalData ( p_person, p_random, p_riskFactors );
		}

		// https://www.heart.org/idc/groups/heart-public/@wcm/@hcm/documents/downloadable/ucm_461840.pdf
		// http://www.webmd.com/heart-disease/guide/heart-disease-prevent#1
		// http://www.betterhealthfacts.com/2013/01/blood-pressure-chart-by-age-and-weight.html
		// https://www.heart.org/idc/groups/heart-public/@wcm/@sop/@smd/documents/downloadable/ucm_319587.pdf
		private static void GenerateBloodPressure ( Person p_person, List<eRiskFactor> p_riskFactors, Random p_random, out int p_sys, out int p_dia ) {
			double weightPercentile = p_person.WeightPercentile;
			int age = p_person.GetAge ( );

			/*double minSys = 120 - ( MathUtil.RandomNormal ( p_random, weightPercentile, 0.2 ) * 30.0 );
			double maxSys = 90.0 + ( MathUtil.RandomNormal ( p_random, weightPercentile, 0.2 ) * 30.0 );
			if ( maxSys < minSys ) {
				double temp = minSys;
				minSys = maxSys;
				maxSys = temp;
			}

			p_sys = p_random.Next ( ( int ) MathUtil.Clamp ( minSys, 90.0, 120.0 ), ( int ) MathUtil.Clamp ( maxSys, 90.0, 120.0 ) );
			p_dia = p_random.Next ( 60, ( int ) MathUtil.Clamp ( ( 60 + ( MathUtil.RandomNormal ( p_random, weightPercentile + 0.5, 0.2 ) * 20.0 ) ), 60.0, 80.0 ) );
			*/

			p_sys = p_random.Next ( 90, 120 );
			p_dia = p_random.Next ( 60, 80 );

			if ( p_random.NextDouble ( ) < 1.0 - weightPercentile ) {
				return;
			}

			double likelehood = 0.225f;
			if ( p_riskFactors.Contains ( eRiskFactor.HEAVY_SMOKER ) ) {
				likelehood += 0.35f;
			} else if ( p_riskFactors.Contains ( eRiskFactor.MODERATE_SMOKER ) ) {
				likelehood += 0.20f;
			} else if ( p_riskFactors.Contains ( eRiskFactor.LIGHT_SMOKER ) ) {
				likelehood += 0.05f;
			}

			if ( p_riskFactors.Contains ( eRiskFactor.HEAVY_DRINKER ) ) {
				likelehood += 0.35f;
			} else if ( p_riskFactors.Contains ( eRiskFactor.MODERATE_DRINKER ) ) {
				likelehood += 0.20f;
			} else if ( p_riskFactors.Contains ( eRiskFactor.LIGHT_DRINKER ) ) {
				likelehood += 0.05f;
			}

			bool high = false;
			if ( p_person.Sex == eSex.MALE ) {
				if ( age < 34 ) {
					likelehood += 0.091;
					high = p_random.NextDouble ( ) < likelehood;
				} else if ( age < 44 ) {
					likelehood += 0.244;
					high = p_random.NextDouble ( ) < likelehood;
				} else if ( age < 54 ) {
					likelehood += 0.377;
					high = p_random.NextDouble ( ) < likelehood;
				} else if ( age < 64 ) {
					likelehood += 0.52;
					high = p_random.NextDouble ( ) < likelehood;
				} else if ( age < 74 ) {
					likelehood += 0.639;
					high = p_random.NextDouble ( ) < likelehood;
				} else {
					likelehood += 0.721;
					high = p_random.NextDouble ( ) < likelehood;
				}
			} else if ( p_person.Sex == eSex.FEMALE ) {
				if ( age < 34 ) {
					likelehood += 0.067;
					high = p_random.NextDouble ( ) < likelehood;
				} else if ( age < 44 ) {
					likelehood += 0.176;
					high = p_random.NextDouble ( ) < likelehood;
				} else if ( age < 54 ) {
					likelehood += 0.34;
					high = p_random.NextDouble ( ) < likelehood;
				} else if ( age < 64 ) {
					likelehood += 0.52;
					high = p_random.NextDouble ( ) < likelehood;
				} else if ( age < 74 ) {
					likelehood += 0.708;
					high = p_random.NextDouble ( ) < likelehood;
				} else {
					likelehood += 0.801;
					high = p_random.NextDouble ( ) < likelehood;
				}
			}

			if ( p_person.Race == eRace.AFRICAN_AMERICAN && p_random.NextDouble ( ) > 0.9 ) {
				high = true;
			}

			if ( high ) {
				// p_sys = p_random.Next ( 120, ( int ) ( 120 + ( weightPercentile * 20.0 ) ) );
				// p_dia = p_random.Next ( 80, ( int ) ( 80 + ( weightPercentile * 10.0 ) ) );

				p_sys = p_random.Next ( 120, 140 );
				p_dia = p_random.Next ( 80, 90 );
			}
		}
	}
}

