using System;

namespace MedicalDataGeneration {

	public enum eSex {
		MALE = 'm',
		FEMALE = 'f',
		UNKNOWN = 'u'
	}

	public enum eRace {
		WHITE = 'w',
		HISPANIC = 'h',
		AFRICAN_AMERICAN = 'f',
		ASIAN = 'a',
		OTHER = 'o'
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

			Race = CreateRace ( p_rand );
			Address = Address.GenerateAddress ( p_rand );
			DateOfBirth = CreateDateOfBirth ( p_rand );
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

			Race = CreateRace ( p_rand );
			Address = Address.GenerateAddress ( p_rand );
			DateOfBirth = CreateDateOfBirth ( p_rand );
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
			Race = CreateRace ( p_rand );
			Address = Address.GenerateAddress ( p_rand );
			DateOfBirth = CreateDateOfBirth ( p_rand );
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
			"Town,State,Zip,Systolic,Diastolic,Risk";
		}

		public string ToCSV ( ) {
			return Name.ToCSV ( ) + "," + Sex + "," + Race + "," + DateOfBirth.ToString ( "MM/dd/yyyy" ) + "," +
			GetAge ( ) + "," + HeightInches + "," + WeightPounds.ToString ( ) + "," + WeightPercentile + "," +
			PNumber.ToString ( ) + "," + SocialSecurityNumber + "," + Address.ToCSV ( ) + "," + MedData.ToCSV ( );
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

		private DateTime CreateDateOfBirth ( Random p_rand ) {
			DateTime start = DateTime.Now.Subtract ( new TimeSpan ( 365 * 80, 0, 0, 0, 0 ) );
			int range = ( DateTime.Now.Subtract ( new TimeSpan ( 365 * 20, 0, 0, 0, 0 ) ) - start ).Days;           
			return start.AddDays ( p_rand.Next ( range ) );
		}

		private eRace CreateRace ( Random p_rand ) {
			double val = p_rand.NextDouble ( );
			if ( val < 0.665 ) {
				return eRace.WHITE;
			} else if ( val < 0.812 ) {
				return eRace.HISPANIC;
			} else if ( val < 0.934 ) {
				return eRace.AFRICAN_AMERICAN;
			} else if ( val < 0.976 ) {
				return eRace.ASIAN;
			}

			return eRace.OTHER;
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
					} else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 5.0 );
					}
				} else if ( age < 40 ) {
					weight = CheckWeight ( p_rand, percentile, 112.2, 118.8, 126.5, 137.2, 159.8, 194.2, 215.1, 225.4, 253.9 );
					if ( p_race == eRace.AFRICAN_AMERICAN ) {
						weight += RandomInRange ( p_rand, 0.0, 7.0 );
					} else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 5.0 );
					}
				} else if ( age < 50 ) {
					weight = CheckWeight ( p_rand, percentile, 111.9, 120.8, 126.5, 134.9, 158.4, 189.0, 212.0, 228.7, 253.2 );
					if ( p_race == eRace.AFRICAN_AMERICAN ) {
						weight += RandomInRange ( p_rand, 6.0, 12.0 );
					} else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 3.0 );
					}
				} else if ( age < 60 ) {
					weight = CheckWeight ( p_rand, percentile, 112.7, 123.3, 128.8, 138.5, 161.4, 193.8, 213.3, 230.2, 255.3 );
					if ( p_race == eRace.AFRICAN_AMERICAN ) {
						weight += RandomInRange ( p_rand, 6.0, 12.0 );
					} else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 2.0 );
					}
				} else if ( age < 70 ) {
					weight = CheckWeight ( p_rand, percentile, 116.5, 126.1, 132.2, 140.4, 165.7, 192.5, 211.0, 226.3, 241.4 );
					if ( p_race == eRace.AFRICAN_AMERICAN ) {
						weight += RandomInRange ( p_rand, 6.0, 12.0 );
					} else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 5.0 );
					}
				} else {
					weight = CheckWeight ( p_rand, percentile, 109.9, 118.0, 125.7, 136.9, 159.4, 187.1, 201.7, 128.4, 240.6 );
					if ( p_race == eRace.AFRICAN_AMERICAN ) {
						weight += RandomInRange ( p_rand, 6.0, 12.0 );
					} else if ( p_race == eRace.HISPANIC ) {
						weight -= RandomInRange ( p_rand, 0.0, 5.0 );
					}
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

