using System;
using System.Collections.Generic;

namespace MedicalDataGeneration {

	public enum eSex {
		MALE = 'm',
		FEMALE = 'f',
		UNKNOWN = 'u'
	}

	public enum eRace {
		WHITE = 'w',
		AFRICAN_AMERICAN = 'f',
		ASIAN = 'a',
		OTHER = 'o'
	}

	public enum ePrintColumns {
		COLUMN_F_NAME,
		COLUMN_M_NAME,
		COLUMN_L_NAME,
		COLUMN_SEX,
		COLUMN_RACE,
		COLUMN_DOB,
		COLUMN_AGE,
		COLUMN_HEIGHT,
		COLUMN_WEIGHT,
		COLUMN_WEIGHT_PERCENTILE,
		COLUMN_PHONE,
		COLUMN_SSN,
		COLUMN_ADDRESS,
		COLUMN_TOWN,
		COLUMN_STATE,
		COLUMN_ZIP,
		COLUMN_SYSTOLIC,
		COLUMN_DIASTOLIC,
		COLUMN_RISK_FACTORS,
		COLUMN_DISORDERS,
		COLUMN_INCREMENTAL_ID
	}

	public class Person {

		public Name Name;
		public eSex Sex;
		public eRace Race;
		public DateTime DateOfBirth;
		public PhoneNumber PNumber;
		public String SocialSecurityNumber;
		public Address Address;

		public int HeightInches;
		public int WeightPounds;
		public double WeightPercentile;

		public MedicalData MedData;

		public Person ( Random p_rand, int p_systolic, int p_diastolic ) {
			if ( p_rand.NextDouble ( ) < 0.5 ) {
				Name = Name.GenerateMaleName ( p_rand );
				Sex = eSex.MALE;
			} else {
				Name = Name.GenerateFemaleName ( p_rand );
				Sex = eSex.FEMALE;
			}

			DateOfBirth = CreateDateOfBirth ( p_rand );
			Race = CreateRace ( p_rand, DateOfBirth.Year );

			Address = Address.GenerateAddress ( p_rand );
			PNumber = new PhoneNumber ( Address.City.Town, p_rand );
			SocialSecurityNumber = GenerateSocialSecurity ( p_rand );

			HeightInches = CreateHeightInches ( p_rand );
			WeightPounds = CreateWeightPounds ( p_rand, Race, Address.City.Abbreviation );
			MedData = new MedicalData ( p_systolic, p_diastolic );
		}

		public Person ( Random p_rand, params eRiskFactor[] p_riskFactors ) {
			if ( p_rand.NextDouble ( ) < 0.5 ) {
				Name = Name.GenerateMaleName ( p_rand );
				Sex = eSex.MALE;
			} else {
				Name = Name.GenerateFemaleName ( p_rand );
				Sex = eSex.FEMALE;
			}

			DateOfBirth = CreateDateOfBirth ( p_rand );
			Race = CreateRace ( p_rand, DateOfBirth.Year );

			Address = Address.GenerateAddress ( p_rand );
			PNumber = new PhoneNumber ( Address.City.Town, p_rand );
			SocialSecurityNumber = GenerateSocialSecurity ( p_rand );

			HeightInches = CreateHeightInches ( p_rand );
			WeightPounds = CreateWeightPounds ( p_rand, Race, Address.City.Abbreviation );
			MedData = MedicalData.GenerateMedicalData ( this, p_rand, p_riskFactors );
		}

		public Person ( eSex p_sex, Random p_rand ) {
			if ( p_sex == eSex.MALE ) {
				Name = Name.GenerateMaleName ( p_rand );
			} else if ( p_sex == eSex.FEMALE ) {
					Name = Name.GenerateFemaleName ( p_rand );
				} else {
					Name = Name.GenerateObfuscatedName ( p_rand );
				}

			Sex = p_sex;
			DateOfBirth = CreateDateOfBirth ( p_rand );
			Race = CreateRace ( p_rand, DateOfBirth.Year ); // Race depends on year born in US

			Address = Address.GenerateAddress ( p_rand );
			PNumber = new PhoneNumber ( Address.City.Town, p_rand );
			SocialSecurityNumber = GenerateSocialSecurity ( p_rand );

			HeightInches = CreateHeightInches ( p_rand );
			WeightPounds = CreateWeightPounds ( p_rand, Race, Address.City.Abbreviation );
			MedData = MedicalData.GenerateMedicalData ( this, p_rand );
		}

		public Person ( Random p_rand ) {
			if ( p_rand.NextDouble ( ) < 0.5 ) {
				Name = Name.GenerateMaleName ( p_rand );
				Sex = eSex.MALE;
			} else {
				Name = Name.GenerateFemaleName ( p_rand );
				Sex = eSex.FEMALE;
			}

			DateOfBirth = DateTime.Now - new TimeSpan ( 365 * 19, 1, 1, 1 );

			Address = Address.GenerateAddress ( p_rand );
			PNumber = new PhoneNumber ( Address.City.Town, p_rand );
			SocialSecurityNumber = GenerateSocialSecurity ( p_rand );

			HeightInches = CreateHeightInches ( p_rand );
			WeightPounds = CreateWeightPounds ( p_rand, Race, Address.City.Abbreviation );
			MedData = MedicalData.GenerateMedicalData ( this, p_rand );
		}

		public override string ToString ( ) {
			return Name.ToString ( ) + "\n" +
			Sex + ", " + Race + ", " + DateOfBirth.ToString ( "MM/dd/yyyy" ) + " ( " + GetAge ( ) + " )\n" +
			GetHeight ( ) + ", " + WeightPounds.ToString ( ) + " lbs.\n" +
			"Phone Number: " + PNumber.ToString ( ) + "\n" +
			"SSN: " + SocialSecurityNumber + "\n" +
			Address.ToString ( ) + "\n" +
			"Medical Data:\n" +
			MedData.ToString ( );
		}

		public static string Header ( ) {
			/*return "First Name,Middle Name,Last Name,Sex,Race,Date of Birth,Age (Years)," +
			"Height (Inches),Weight (Lbs.),Weight Percentile,Phone Number,SSSN,Address," +
			"Town,State,Zip Code,Systolic,Diastolic";*/
			return "First,Middle,Last,Sex,Race,DoB,Age," +
			"Height,Weight,Percentile,PNum,SSN,Address," +
			"Town,State,Zip,Systolic,Diastolic,Risk_Factors,Disorders";
		}

		public static string Header ( params ePrintColumns[] p_columns ) {
			string ret = "";
			for ( int i = 0; i < p_columns.Length; i++ ) {
				ePrintColumns col = p_columns [ i ];
				switch ( col ) {
					case ePrintColumns.COLUMN_F_NAME:
						ret += "First,";
						break;
					case ePrintColumns.COLUMN_M_NAME:
						ret += "Middle,";
						break;
					case ePrintColumns.COLUMN_L_NAME:
						ret += "Last,";
						break;
					case ePrintColumns.COLUMN_SEX
					:
						ret += "Sex,";
						break;
					case ePrintColumns.COLUMN_RACE:
						ret += "Race,";
						break;
					case ePrintColumns.COLUMN_DOB:
						ret += "DoB,";
						break;
					case ePrintColumns.COLUMN_AGE:
						ret += "Age,";
						break;
					case ePrintColumns.COLUMN_HEIGHT:
						ret += "Height,";
						break;
					case ePrintColumns.COLUMN_WEIGHT:
						ret += "Weight,";
						break;
					case ePrintColumns.COLUMN_WEIGHT_PERCENTILE:
						ret += "Percentile,";
						break;
					case ePrintColumns.COLUMN_PHONE:
						ret += "Phone,";
						break;
					case ePrintColumns.COLUMN_SSN:
						ret += "SSN,";
						break;
					case ePrintColumns.COLUMN_ADDRESS:
						ret += "Address,";
						break;
					case ePrintColumns.COLUMN_TOWN:
						ret += "Town,";
						break;
					case ePrintColumns.COLUMN_STATE:
						ret += "State,";
						break;
					case ePrintColumns.COLUMN_ZIP:
						ret += "Zip,";
						break;
					case ePrintColumns.COLUMN_SYSTOLIC:
						ret += "Systolic,";
						break;
					case ePrintColumns.COLUMN_DIASTOLIC:
						ret += "Diastolic,";
						break;
					case ePrintColumns.COLUMN_RISK_FACTORS:
						ret += "Risk_Factors,";
						break;
					case ePrintColumns.COLUMN_DISORDERS:
						ret += "Disorders,";
						break;
				}
			}

			ret = ret.Substring ( 0, ret.Length - 1 );
			return ret;
		}

		public string ToCSV ( ) {
			return Name.ToCSV ( ) + "," + Sex + "," + Race + "," + DateOfBirth.ToString ( "MM/dd/yyyy" ) + "," +
			GetAge ( ) + "," + HeightInches + "," + WeightPounds.ToString ( ) + "," + WeightPercentile + "," +
			PNumber.ToString ( ) + "," + SocialSecurityNumber + "," + Address.ToCSV ( ) + "," + MedData.ToCSV ( );
		}

		public string ToCSV ( params ePrintColumns[] p_columns ) {
			string ret = "";
			for ( int i = 0; i < p_columns.Length; i++ ) {
				ePrintColumns col = p_columns [ i ];
				switch ( col ) {
					case ePrintColumns.COLUMN_F_NAME:
						ret += Name.FirstName + ",";
						break;
					case ePrintColumns.COLUMN_M_NAME:
						ret += Name.MiddleName + ",";
						break;
					case ePrintColumns.COLUMN_L_NAME:
						ret += Name.LastName + ",";
						break;
					case ePrintColumns.COLUMN_SEX:
						ret += Sex + ",";
						break;
					case ePrintColumns.COLUMN_RACE:
						ret += Race + ",";
						break;
					case ePrintColumns.COLUMN_DOB:
						ret += DateOfBirth.ToString ( "MM/dd/yyyy" ) + ",";
						break;
					case ePrintColumns.COLUMN_AGE:
						ret += GetAge ( ) + ",";
						break;
					case ePrintColumns.COLUMN_HEIGHT:
						ret += HeightInches + ",";
						break;
					case ePrintColumns.COLUMN_WEIGHT:
						ret += WeightPounds.ToString ( ) + ",";
						break;
					case ePrintColumns.COLUMN_WEIGHT_PERCENTILE:
						ret += WeightPercentile + ",";
						break;
					case ePrintColumns.COLUMN_PHONE:
						ret += PNumber.ToString ( ) + ",";
						break;
					case ePrintColumns.COLUMN_SSN:
						ret += SocialSecurityNumber + ",";
						break;
					case ePrintColumns.COLUMN_ADDRESS:
						ret += Address.Street.ToString ( ) + ",";
						break;
					case ePrintColumns.COLUMN_TOWN:
						ret += Address.City.Town + ",";
						break;
					case ePrintColumns.COLUMN_STATE:
						ret += Address.City.State + ",";
						break;
					case ePrintColumns.COLUMN_ZIP:
						ret += Address.City.ZipCode + ",";
						break;
					case ePrintColumns.COLUMN_SYSTOLIC:
						ret += MedData.Systolic + ",";
						break;
					case ePrintColumns.COLUMN_DIASTOLIC:
						ret += MedData.Diastolic + ",";
						break;
					case ePrintColumns.COLUMN_RISK_FACTORS:
						ret += MedData.RiskFactorsToString ( ) + ",";
						break;
					case ePrintColumns.COLUMN_DISORDERS:
						ret += MedData.DisordersToString ( ) + ",";
						break;
				}
			}

			ret = ret.Substring ( 0, ret.Length - 1 );
			return ret;
		}

		public int GetAge ( ) {
			return ( DateTime.Now - DateOfBirth ).Days / 365;
		}

		public char GetSex ( ) {
			return ( char ) Sex;
		}

		public string GetHeight ( ) {
			return ( HeightInches / 12 ).ToString ( ) + "' " + ( HeightInches % 12 ).ToString ( ) + "\"";
		}

		public bool HasDisorder ( string p_disorder ) {
			return MedData.HasDisorder ( p_disorder );
		}

		public void CreateDisorder ( Random p_rand, List<string> p_disorders, int p_numDisordersToHave ) {
			if ( p_disorders.Count > 0 ) {
				List<int> values = new List<int> ( );
				for ( int i = 0; i < p_disorders.Count; i++ ) {
					values.Add ( i );
				}

				values.Shuffle ( p_rand );

				for ( int i = 0; i < p_numDisordersToHave; i++ ) {
					MedData.Disorders.Add ( p_disorders [ values [ i ] ] );
				}
			}
		}

		public void AddDisorder ( string p_disorder ) {
			MedData.Disorders.Add ( p_disorder );
		}

		public void AddRiskFactor ( eRiskFactor p_riskFactor ) {
			MedData.RiskFactors.Add ( p_riskFactor );
		}

		public void GiveHighBloodPressure ( Random p_random ) {
			MedData.Systolic = p_random.Next ( 120, 179 );
			MedData.Diastolic = p_random.Next ( 80, 109 );
		}

		public void GiveNormalBloodPressure ( Random p_random ) {
			MedData.Systolic = p_random.Next ( 90, 120 );
			MedData.Diastolic = p_random.Next ( 60, 80 );
		}

		public void GiveLowBloodPressure ( Random p_random ) {
			MedData.Systolic = p_random.Next ( 70, 90 );
			MedData.Diastolic = p_random.Next ( 50, 60 );
		}

		private DateTime CreateDateOfBirth ( Random p_rand ) {
			DateTime start = new DateTime ( 1940, 1, 1, 1, 1, 1 ); // First person can be born on January 1, 1940
			int range = ( DateTime.Now.Subtract ( new TimeSpan ( 365 * 20, 0, 0, 0, 0 ) ) - start ).Days; // Everyone must be at least 20           
			return start.AddDays ( p_rand.Next ( range ) );
		}

		public void CreateDateOfBirthInRange ( Random p_random, int p_minAge, int p_maxAge ) {
			DateTime start = DateTime.Now.Subtract ( new TimeSpan ( p_maxAge * 365, 0, 0, 0 ) );
			int range = ( DateTime.Now.Subtract ( new TimeSpan ( p_minAge * 365, 0, 0, 0 ) ) - start ).Days;

			DateOfBirth = start.AddDays ( p_random.Next ( range ) );
			Race = CreateRace ( p_random, DateOfBirth.Year );
		}

		public void CreateDateOfBirthOutOfRange ( Random p_random, int p_minAge, int p_maxAge ) {
			if ( p_random.NextDouble ( ) < 0.5f ) {
				CreateDateOfBirthInRange ( p_random, 1, p_minAge );
			} else {
				CreateDateOfBirthInRange ( p_random, p_maxAge, Math.Min ( 70, p_maxAge * 3 ) );
			}
		}

		public void CreateDateOfBirthLessThanAge ( Random p_random, int p_age ) {
			CreateDateOfBirthInRange ( p_random, 1, p_age );
		}

		public void CreateDateOfBirthGreaterThanAge ( Random p_random, int p_age ) {
			CreateDateOfBirthInRange ( p_random, p_age, Math.Min ( 70, p_age * 3 ) );
		}

		public void CreateDateOfBirthWithAge ( Random p_random ) {
			throw new NotImplementedException ( "Error: Cannot create date of birth with specific age" );
		}

		private eRace CreateRace ( Random p_rand, int p_yearBorn ) {
			p_yearBorn -= 1939; 
			p_yearBorn /= 10; // Prep for array data

			float val = p_rand.NextFloat ( );
			float sum = 0.0f;
			for ( int i = 0; i < Constraints.PersonConstraints.sRaceRatios.Length; i++ ) {
				sum += Constraints.PersonConstraints.sRaceRatios [ p_yearBorn, i ];
				if ( val < sum ) {
					return RaceFromIndex ( i );
				}
			}

			return eRace.OTHER;
		}

		private eRace RaceFromIndex ( int p_index ) {
			switch ( p_index ) {
				case 0:
					return eRace.WHITE;
				case 1:
					return eRace.AFRICAN_AMERICAN;
				case 2:
					return eRace.ASIAN;
				default:
					return eRace.OTHER;
			}
		}

		// https://www2.census.gov/library/publications/2010/compendia/statab/130ed/tables/11s0205.pdf
		private int CreateHeightInches ( Random p_rand ) {
			int age = GetAge ( );
			int height = 0;

			double val = p_rand.NextDouble ( );
			if ( Sex == eSex.MALE ) {
				if ( age < 30 ) {
					height = CheckHeights ( val, 0.0, 0.0, 0.0, 0.0, 
						0.0, 0.0, 0.037, 0.072, 0.116, 0.206, 0.331, 0.422,
						0.586, 0.707, 0.799, 0.89, 0.941, 0.983, 1, 1, 1 );
				} else if ( age < 40 ) {
						height = CheckHeights ( val, 0.0, 0.0, 0.0, 0.0, 0.0, 
							0.031, 0.044, 0.067, 0.131, 0.196, 0.322, 0.454, 0.581, 
							0.694, 0.785, 0.89, 0.94, 0.958, 0.976, 0.994, 1 );
					} else if ( age < 50 ) {
							height = CheckHeights ( val, 0.0, 0.0, 0.0, 0.0, 0.0, 
								0.019, 0.038, 0.056, 0.098, 0.194, 0.303, 0.404, 0.544,
								0.696, 0.791, 0.874, 0.925, 0.977, 0.99, 0.994, 1 );
						} else if ( age < 60 ) {
								height = CheckHeights ( val, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 
									0.043, 0.076, 0.122, 0.186, 0.303, 0.412, 0.543, 0.7, 0.812, 
									0.916, 0.937, 0.966, 0.995, 0.996, 1 );
							} else if ( age < 70 ) {
									height = CheckHeights ( val, 0.0, 0.0, 0.0, 0.004, 0.01, 0.023, 
										0.044, 0.078, 0.147, 0.237, 0.377, 0.502, 0.652, 0.75, 0.843, 0.936, 
										0.978, 0.999, 1, 1, 1 );
								} else {
									height = CheckHeights ( val, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 
										0.058, 0.128, 0.23, 0.351, 0.477, 0.603, 0.752, 0.858, 
										0.91, 0.949, 0.986, 1, 1, 1, 1 );
								}
			} else if ( Sex == eSex.FEMALE ) {
					if ( age < 30 ) {
						height = CheckHeights ( val, 0.0, 0.026, 0.057, 0.123, 
							0.208, 0.304, 0.435, 0.541, 0.724, 0.823, 0.903, 0.941,
							0.976, 0.996, 1, 1, 1, 1, 1, 1, 1 );
					} else if ( age < 40 ) {
							height = CheckHeights ( val, 0.017, 0.031, 0.06, 0.116, 0.197, 0.313,
								0.466, 0.612, 0.74, 0.849, 0.918, 0.961, 0.989, 0.99, 0.994, 0.999,
								1, 1, 1, 1, 1 );
						} else if ( age < 50 ) {
								height = CheckHeights ( val, 0.0, 0.016, 0.050, 0.108, 0.198, 0.308, 
									0.460, 0.58, 0.722, 0.83, 0.912, 0.947, 0.978, 0.994, 0.995, 0.996, 
									0.997, 0.998, 0.999, 1, 1 );
							} else if ( age < 60 ) {
									height = CheckHeights ( val, 0.01, 0.021, 0.08, 0.167, 0.233, 0.363, 
										0.507, 0.684, 0.797, 0.884, 0.952, 0.973, 0.989, 1, 1, 
										1, 1, 1, 1, 1, 1 );
								} else if ( age < 70 ) {
										height = CheckHeights ( val, 0.0, 0.036, 0.09, 0.147, 0.234,
											0.384, 0.528, 0.666, 0.833, 0.933, 0.97, 0.978,
											0.996, 0.998, 0.999, 1, 1, 1, 1, 1, 1 );
									} else {
										height = CheckHeights ( val, 0.033, 0.087, 0.16, 0.26, 0.369, 0.519,
											0.699, 0.828, 0.893, 0.954, 0.984, 0.996, 0.997, 
											1, 1, 1, 1, 1, 1, 1, 1 );
									}
				}

			return height;
		}

		// https://www.cdc.gov/nchs/data/series/sr_11/sr11_014acc.pdf
		// See chart on Page 16

		// https://www.cdc.gov/nchs/data/series/sr_11/sr11_252.pdf
		// See Charts on Page 8 and 10
		private int CreateWeightPounds ( Random p_rand, eRace p_race, string p_state ) {
			int age = GetAge ( );
			double weight = 0.0;

			double percentile = p_rand.NextDouble ( );
			// GENERATE OUTLIERS
			if ( p_state == "AL" || p_state == "WV" ) {
				if ( p_rand.NextDouble ( ) <= 0.13f ) {
					percentile = p_rand.NextDouble ( ) + 0.5;
					if ( percentile > 1.0 ) {
						percentile = 1.0;
					}
				}
			}

			WeightPercentile = percentile;

			if ( Sex == eSex.MALE ) {
				if ( age < 30 ) {
					weight = CheckWeight ( p_rand, percentile, 128.7, 137.9, 143.9, 153.2, 176.5, 206.6, 224.0, 240.4, 257.5 );
				} else if ( age < 40 ) {
						weight = CheckWeight ( p_rand, percentile, 139.6, 149.4, 156.0, 166.2, 191.1, 222.9, 242.7, 259.7, 282.2 );
					} else if ( age < 50 ) {
							weight = CheckWeight ( p_rand, percentile, 142.1, 153.2, 162.0, 173.1, 193.7, 221.9, 239.4, 256.1, 278.5 );
							if ( p_race == eRace.WHITE ) {
								weight += RandomInRange ( p_rand, 0.0, 7.0 );
							} else if ( p_race == eRace.AFRICAN_AMERICAN ) {
									weight -= RandomInRange ( p_rand, 0.0, 5.0 );
								}
						} else if ( age < 60 ) {
								weight = CheckWeight ( p_rand, percentile, 140.6, 152.2, 160.8, 172.3, 195.4, 226.9, 242.1, 259.3, 279.0 );
								if ( p_race == eRace.WHITE ) {
									weight += RandomInRange ( p_rand, 0.0, 7.0 );
								} else if ( p_race == eRace.AFRICAN_AMERICAN ) {
										weight -= RandomInRange ( p_rand, 0.0, 5.0 );
									}
							} else if ( age < 70 ) {
									weight = CheckWeight ( p_rand, percentile, 135.9, 149.8, 156.2, 168.5, 195.1, 224.0, 238.7, 253.8, 280.8 );
									if ( p_race == eRace.WHITE ) {
										weight += RandomInRange ( p_rand, 0.0, 7.0 );
									}
								} else {
									weight = CheckWeight ( p_rand, percentile, 138.1, 147.2, 155.1, 165.5, 186.8, 209.8, 227.0, 241.1, 259.9 );
									if ( p_race == eRace.WHITE ) {
										weight += RandomInRange ( p_rand, 0.0, 12.0 );
									}
								}
			} else if ( Sex == eSex.FEMALE ) {
					if ( age < 30 ) {
						weight = CheckWeight ( p_rand, percentile, 107.2, 114.8, 118.5, 126.3, 149.4, 181.2, 208.9, 227.3, 264.5 );
						if ( p_race == eRace.AFRICAN_AMERICAN ) {
							weight += RandomInRange ( p_rand, 0.0, 7.0 );
						} /*else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 5.0 );
					}*/
					} else if ( age < 40 ) {
							weight = CheckWeight ( p_rand, percentile, 112.2, 118.8, 126.5, 137.2, 159.8, 194.2, 215.1, 225.4, 253.9 );
							if ( p_race == eRace.AFRICAN_AMERICAN ) {
								weight += RandomInRange ( p_rand, 0.0, 7.0 );
							} /*else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 5.0 );
					}*/
						} else if ( age < 50 ) {
								weight = CheckWeight ( p_rand, percentile, 111.9, 120.8, 126.5, 134.9, 158.4, 189.0, 212.0, 228.7, 253.2 );
								if ( p_race == eRace.AFRICAN_AMERICAN ) {
									weight += RandomInRange ( p_rand, 6.0, 12.0 );
								} /*else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 3.0 );
					}*/
							} else if ( age < 60 ) {
									weight = CheckWeight ( p_rand, percentile, 112.7, 123.3, 128.8, 138.5, 161.4, 193.8, 213.3, 230.2, 255.3 );
									if ( p_race == eRace.AFRICAN_AMERICAN ) {
										weight += RandomInRange ( p_rand, 6.0, 12.0 );
									} /*else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 2.0 );
					}*/
								} else if ( age < 70 ) {
										weight = CheckWeight ( p_rand, percentile, 116.5, 126.1, 132.2, 140.4, 165.7, 192.5, 211.0, 226.3, 241.4 );
										if ( p_race == eRace.AFRICAN_AMERICAN ) {
											weight += RandomInRange ( p_rand, 6.0, 12.0 );
										} /*else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 5.0 );
					}*/
									} else {
										weight = CheckWeight ( p_rand, percentile, 109.9, 118.0, 125.7, 136.9, 159.4, 187.1, 201.7, 128.4, 240.6 );
										if ( p_race == eRace.AFRICAN_AMERICAN ) {
											weight += RandomInRange ( p_rand, 6.0, 12.0 );
										} /*else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 5.0 );
					}*/
									}
				}

			return ( int ) weight;
		}

		private string GenerateSocialSecurity ( Random p_rand ) {
			return "000-" + p_rand.Next ( 100 ).ToString ( "D2" ) + "-" + p_rand.Next ( 10000 ).ToString ( "D4" );
		}

		private double CheckWeight ( Random p_rand, double p_percentile, double p_0, double p_1, double p_2, double p_3, double p_4, double p_5, double p_6, double p_7, double p_8 ) {
			if ( p_percentile < 0.05 ) {
				return RandomInRange ( p_rand, p_0 - ( p_1 - p_0 ), p_1 );
			} else if ( p_percentile < 0.1 ) {
					return RandomInRange ( p_rand, p_1, p_2 );
				} else if ( p_percentile < 0.15 ) {
						return RandomInRange ( p_rand, p_2, p_3 );
					} else if ( p_percentile < 0.25 ) {
							return RandomInRange ( p_rand, p_3, p_4 );
						} else if ( p_percentile < 0.50 ) {
								return RandomInRange ( p_rand, p_4, p_5 );
							} else if ( p_percentile < 0.75 ) {
									return RandomInRange ( p_rand, p_5, p_6 );
								} else if ( p_percentile < 0.85 ) {
										return RandomInRange ( p_rand, p_6, p_7 );
									} else if ( p_percentile < 0.90 ) {
											return RandomInRange ( p_rand, p_7, p_8 );
										} else if ( p_percentile < 0.95 ) {
												return RandomInRange ( p_rand, p_8, p_8 + ( p_8 - p_7 ) );
											}

			return RandomInRange ( p_rand, p_8 + ( p_8 - p_7 ), p_8 + ( p_8 - p_7 ) * 2.0 );
		}

		private int CheckHeights ( double p_val, double p_0, double p_1, double p_2, double p_3, double p_4, double p_5, double p_6, double p_7, double p_8, double p_9, double p_10, double p_11, double p_12, double p_13, double p_14, double p_15, double p_16, double p_17, double p_18, double p_19, double p_20 ) {
			if ( p_val < p_0 ) {
				return 58;
			} else if ( p_val < p_1 ) {
					return 59;
				} else if ( p_val < p_2 ) {
						return 60;
					} else if ( p_val < p_3 ) {
							return 61;
						} else if ( p_val < p_4 ) {
								return 62;
							} else if ( p_val < p_5 ) {
									return 63;
								} else if ( p_val < p_6 ) {
										return 64;
									} else if ( p_val < p_7 ) {
											return 65;
										} else if ( p_val < p_8 ) {
												return 66;
											} else if ( p_val < p_9 ) {
													return 67;
												} else if ( p_val < p_10 ) {
														return 68;
													} else if ( p_val < p_11 ) {
															return 69;
														} else if ( p_val < p_12 ) {
																return 70;
															} else if ( p_val < p_13 ) {
																	return 71;
																} else if ( p_val < p_14 ) {
																		return 72;
																	} else if ( p_val < p_15 ) {
																			return 73;
																		} else if ( p_val < p_16 ) {
																				return 74;
																			} else if ( p_val < p_17 ) {
																					return 75;
																				} else if ( p_val < p_18 ) {
																						return 76;
																					} else if ( p_val < p_19 ) {
																							return 77;
																						} else if ( p_val < p_20 ) {
																								return 78;
																							}
			return 70;
		}

		public double RandomInRange ( Random p_rand, double p_min, double p_max ) { 
			return p_rand.NextDouble ( ) * ( p_max - p_min ) + p_min;
		}
	}
}

