﻿using System;

namespace MedicalDataGeneration {

	public struct City {

		public string Town;
		public string State;
		public string Abbreviation;
		public string County;

		public int ZipCode;
		public float Latitude;
		public float Longitude;

		public City ( int p_zip, string p_town, string p_state, string p_abbreviation, string p_county, double p_latitude, double p_longitude ) {
			Town = p_town;
			State = p_state;
			Abbreviation = p_abbreviation;
			County = p_county;

			ZipCode = p_zip;
			Latitude = ( float ) p_latitude;
			Longitude = ( float ) p_longitude;
		}

		public override string ToString ( ) {
			return Town + ", " + Abbreviation + " " + ZipCode.ToString ( "D5" );
		}

		public string ToCSV ( ) {
			return Town + "," + State + "," + ZipCode.ToString ( "D5" );
		}

		public static City GetRandomCity ( Random p_rand ) {
			return Cities [ p_rand.Next ( Cities.Length - 1 ) ];
		}

		public static City[] Cities = new City[] {
			new City ( 35203, "Birmingham", "Alabama", "AL", "Jefferson", 33.521, -86.8066 ),
			new City ( 35813, "Huntsville", "Alabama", "AL", "Madison", 34.734, -86.5229 ),
			new City ( 36601, "Mobile", "Alabama", "AL", "Mobile", 30.7011, -88.1032 ),
			new City ( 36119, "Montgomery", "Alabama", "AL", "Montgomery", 32.2334, -86.2085 ),
			new City ( 99599, "Anchorage", "Alaska", "AK", "Anchorage Municipality", 61.1872, -149.8804 ),
			new City ( 85225, "Chandler", "Arizona", "AZ", "Maricopa", 33.3105, -111.8239 ),
			new City ( 85296, "Gilbert", "Arizona", "AZ", "Maricopa", 33.3354, -111.7406 ),
			new City ( 85302, "Glendale", "Arizona", "AZ", "Maricopa", 33.5675, -112.1753 ),
			new City ( 85201, "Mesa", "Arizona", "AZ", "Maricopa", 33.4317, -111.8469 ),
			new City ( 85381, "Peoria", "Arizona", "AZ", "Maricopa", 33.6048, -112.2237 ),
			new City ( 85026, "Phoenix", "Arizona", "AZ", "Maricopa", 33.2765, -112.1872 ),
			new City ( 85251, "Scottsdale", "Arizona", "AZ", "Maricopa", 33.4936, -111.9167 ),
			new City ( 85282, "Tempe", "Arizona", "AZ", "Maricopa", 33.3917, -111.9249 ),
			new City ( 85726, "Tucson", "Arizona", "AZ", "Pima", 32.2027, -110.9453 ),
			new City ( 72202, "Little Rock", "Arkansas", "AR", "Pulaski", 34.7363, -92.2741 ),
			new City ( 92803, "Anaheim", "California", "CA", "Orange", 33.8397, -117.9388 ),
			new City ( 94509, "Antioch", "California", "CA", "Contra Costa", 37.9939, -121.8089 ),
			new City ( 93380, "Bakersfield", "California", "CA", "Kern", 35.2944, -118.9052 ),
			new City ( 94704, "Berkeley", "California", "CA", "Alameda", 37.8664, -122.257 ),
			new City ( 91505, "Burbank", "California", "CA", "Los Angeles", 34.169, -118.3442 ),
			new City ( 91910, "Chula Vista", "California", "CA", "San Diego", 32.6371, -117.0676 ),
			new City ( 94520, "Concord", "California", "CA", "Contra Costa", 37.9823, -122.0362 ),
			new City ( 91718, "Corona", "California", "CA", "Riverside", 33.7529, -116.0556 ),
			new City ( 92628, "Costa Mesa", "California", "CA", "Orange", 33.6401, -117.9159 ),
			new City ( 94015, "Daly City", "California", "CA", "San Mateo", 37.6787, -122.478 ),
			new City ( 90241, "Downey", "California", "CA", "Los Angeles", 33.9416, -118.1306 ),
			new City ( 91734, "El Monte", "California", "CA", "Los Angeles", 33.7866, -118.2987 ),
			new City ( 95624, "Elk Grove", "California", "CA", "Sacramento", 38.4232, -121.3599 ),
			new City ( 92025, "Escondido", "California", "CA", "San Diego", 33.1101, -117.07 ),
			new City ( 94533, "Fairfield", "California", "CA", "Solano", 38.2671, -122.0356 ),
			new City ( 92335, "Fontana", "California", "CA", "San Bernardino", 34.0794, -117.4551 ),
			new City ( 94537, "Fremont", "California", "CA", "Alameda", 37.6802, -121.9215 ),
			new City ( 93706, "Fresno", "California", "CA", "Fresno", 36.6486, -119.9987 ),
			new City ( 92834, "Fullerton", "California", "CA", "Orange", 33.8768, -117.897 ),
			new City ( 92842, "Garden Grove", "California", "CA", "Orange", 33.7783, -117.9456 ),
			new City ( 91205, "Glendale", "California", "CA", "Los Angeles", 34.1378, -118.2424 ),
			new City ( 94544, "Hayward", "California", "CA", "Alameda", 37.6374, -122.067 ),
			new City ( 92647, "Huntington Beach", "California", "CA", "Orange", 33.721, -118.0033 ),
			new City ( 90301, "Inglewood", "California", "CA", "Los Angeles", 33.955, -118.3556 ),
			new City ( 92619, "Irvine", "California", "CA", "Orange", 33.6706, -117.7645 ),
			new City ( 93534, "Lancaster", "California", "CA", "Los Angeles", 34.6909, -118.1491 ),
			new City ( 90802, "Long Beach", "California", "CA", "Los Angeles", 33.7706, -118.182 ),
			new City ( 90052, "Los Angeles", "California", "CA", "Los Angeles", 33.7866, -118.2987 ),
			new City ( 95350, "Modesto", "California", "CA", "Stanislaus", 37.6746, -121.0113 ),
			new City ( 92553, "Moreno Valley", "California", "CA", "Riverside", 33.9157, -117.2351 ),
			new City ( 90650, "Norwalk", "California", "CA", "Los Angeles", 33.9056, -118.0818 ),
			new City ( 94612, "Oakland", "California", "CA", "Alameda", 37.8085, -122.2668 ),
			new City ( 92054, "Oceanside", "California", "CA", "San Diego", 33.2072, -117.3573 ),
			new City ( 91761, "Ontario", "California", "CA", "San Bernardino", 34.0316, -117.6187 ),
			new City ( 92863, "Orange", "California", "CA", "Orange", 33.8153, -117.8273 ),
			new City ( 93030, "Oxnard", "California", "CA", "Ventura", 34.2141, -119.175 ),
			new City ( 93550, "Palmdale", "California", "CA", "Los Angeles", 34.4133, -118.0917 ),
			new City ( 91103, "Pasadena", "California", "CA", "Los Angeles", 34.1669, -118.1551 ),
			new City ( 91769, "Pomona", "California", "CA", "Los Angeles", 33.7866, -118.2987 ),
			new City ( 91729, "Rancho Cucamonga", "California", "CA", "San Bernardino", 34.84, -115.9671 ),
			new City ( 94801, "Richmond", "California", "CA", "Contra Costa", 37.94, -122.362 ),
			new City ( 92507, "Riverside", "California", "CA", "Riverside", 33.9761, -117.3389 ),
			new City ( 95661, "Roseville", "California", "CA", "Placer", 38.7346, -121.234 ),
			new City ( 95813, "Sacramento", "California", "CA", "Sacramento", 38.6026, -121.4475 ),
			new City ( 93907, "Salinas", "California", "CA", "Monterey", 36.7563, -121.6703 ),
			new City ( 92401, "San Bernardino", "California", "CA", "San Bernardino", 34.1105, -117.2898 ),
			new City ( 93001, "Ventura", "California", "CA", "Ventura", 34.3308, -119.3584 ),
			new City ( 92199, "San Diego", "California", "CA", "San Diego", 32.7516, -117.1918 ),
			new City ( 94188, "San Francisco", "California", "CA", "San Francisco", 37.7848, -122.7278 ),
			new City ( 95101, "San Jose", "California", "CA", "Santa Clara", 37.3894, -121.8868 ),
			new City ( 92711, "Santa Ana", "California", "CA", "Orange", 33.7669, -117.8043 ),
			new City ( 95050, "Santa Clara", "California", "CA", "Santa Clara", 37.3492, -121.953 ),
			new City ( 91355, "Valencia", "California", "CA", "Los Angeles", 34.3985, -118.5535 ),
			new City ( 95402, "Santa Rosa", "California", "CA", "Sonoma", 38.4399, -122.7096 ),
			new City ( 93065, "Simi Valley", "California", "CA", "Ventura", 34.2656, -118.7653 ),
			new City ( 95208, "Stockton", "California", "CA", "San Joaquin", 37.9304, -121.436 ),
			new City ( 94086, "Sunnyvale", "California", "CA", "Santa Clara", 37.3764, -122.0238 ),
			new City ( 91362, "Thousand Oaks", "California", "CA", "Ventura", 34.1948, -118.8232 ),
			new City ( 90503, "Torrance", "California", "CA", "Los Angeles", 33.8397, -118.3542 ),
			new City ( 94590, "Vallejo", "California", "CA", "Solano", 38.1053, -122.2474 ),
			new City ( 93277, "Visalia", "California", "CA", "Tulare", 36.3114, -119.3065 ),
			new City ( 91793, "West Covina", "California", "CA", "Los Angeles", 33.7866, -118.2987 ),
			new City ( 80004, "Arvada", "Colorado", "CO", "Jefferson", 39.8141, -105.1177 ),
			new City ( 80017, "Aurora", "Colorado", "CO", "Arapahoe", 39.6948, -104.7881 ),
			new City ( 80903, "Colorado Springs", "Colorado", "CO", "El Paso", 38.8388, -104.8145 ),
			new City ( 80202, "Denver", "Colorado", "CO", "Denver", 39.7491, -104.9946 ),
			new City ( 80525, "Fort Collins", "Colorado", "CO", "Larimer", 40.5384, -105.0547 ),
			new City ( 80202, "Denver", "Colorado", "CO", "Denver", 39.7491, -104.9946 ),
			new City ( 81003, "Pueblo", "Colorado", "CO", "Pueblo", 38.2843, -104.6234 ),
			new City ( 80221, "Denver", "Colorado", "CO", "Adams", 39.838, -104.9988 ),
			new City ( 80030, "Westminster", "Colorado", "CO", "Adams", 39.8302, -105.037 ),
			new City ( 06602, "Bridgeport", "Connecticut", "CT", "Fairfield", 41.1798, -73.189 ),
			new City ( 06101, "Hartford", "Connecticut", "CT", "Hartford", 41.7801, -72.6771 ),
			new City ( 06511, "New Haven", "Connecticut", "CT", "New Haven", 41.3184, -72.9318 ),
			new City ( 06904, "Stamford", "Connecticut", "CT", "Fairfield", 41.3089, -73.3637 ),
			new City ( 06702, "Waterbury", "Connecticut", "CT", "New Haven", 41.5566, -73.0385 ),
			new City ( 20090, "Washington", "District of Columbia", "DC", "District of Columbia", 38.8933, -77.0146 ),
			new City ( 33909, "Cape Coral", "Florida", "FL", "Lee", 26.6939, -81.9452 ),
			new City ( 33990, "Cape Coral", "Florida", "FL", "Lee", 26.6265, -81.9677 ),
			new City ( 33075, "Pompano Beach", "Florida", "FL", "Broward", 26.1457, -80.4483 ),
			new City ( 33310, "Fort Lauderdale", "Florida", "FL", "Broward", 26.1443, -80.2069 ),
			new City ( 32601, "Gainesville", "Florida", "FL", "Alachua", 29.6489, -82.325 ),
			new City ( 33010, "Hialeah", "Florida", "FL", "Miami - Dade", 25.8325, -80.2808 ),
			new City ( 33022, "Hollywood", "Florida", "FL", "Broward", 26.0134, -80.1442 ),
			new City ( 32203, "Jacksonville", "Florida", "FL", "Duval", 30.3228, -81.547 ),
			new City ( 33152, "Miami", "Florida", "FL", "Miami - Dade", 25.7955, -80.3129 ),
			new City ( 33023, "Hollywood", "Florida", "FL", "Broward", 25.9894, -80.2153 ),
			new City ( 32802, "Orlando", "Florida", "FL", "Orange", 28.519, -81.3439 ),
			new City ( 33024, "Hollywood", "Florida", "FL", "Broward", 26.0296, -80.2489 ),
			new City ( 33060, "Pompano Beach", "Florida", "FL", "Broward", 26.2315, -80.1235 ),
			new City ( 34952, "Port Saint Lucie", "Florida", "FL", "St. Lucie", 27.2889, -80.298 ),
			new City ( 33730, "Saint Petersburg", "Florida", "FL", "Pinellas", 27.8918, -82.7248 ),
			new City ( 32301, "Tallahassee", "Florida", "FL", "Leon", 30.4286, -84.2593 ),
			new City ( 33630, "Tampa", "Florida", "FL", "Hillsborough", 27.872, -82.4388 ),
			new City ( 30608, "Athens", "Georgia", "GA", "Clarke", 33.9443, -83.3891 ),
			new City ( 30304, "Atlanta", "Georgia", "GA", "Fulton", 33.8482, -84.4293 ),
			new City ( 30901, "Augusta", "Georgia", "GA", "Richmond", 33.4601, -81.973 ),
			new City ( 31908, "Columbus", "Georgia", "GA", "Muscogee", 32.5349, -84.9065 ),
			new City ( 31402, "Savannah", "Georgia", "GA", "Chatham", 31.9714, -81.0716 ),
			new City ( 96820, "Honolulu", "Hawaii", "HI", "Honolulu", 24.8598, -168.0218 ),
			new City ( 83708, "Boise", "Idaho", "ID", "Ada", 43.4599, -116.244 ),
			new City ( 60505, "Aurora", "Illinois", "IL", "Kane", 41.7582, -88.2971 ),
			new City ( 60607, "Chicago", "Illinois", "IL", "Cook", 41.8721, -87.6578 ),
			new City ( 60436, "Joliet", "Illinois", "IL", "Will", 41.4884, -88.1572 ),
			new City ( 60540, "Naperville", "Illinois", "IL", "DuPage", 41.7662, -88.141 ),
			new City ( 61601, "Peoria", "Illinois", "IL", "Peoria", 40.6931, -89.5898 ),
			new City ( 61125, "Rockford", "Illinois", "IL", "Winnebago", 42.3254, -89.1705 ),
			new City ( 62703, "Springfield", "Illinois", "IL", "Sangamon", 39.7622, -89.6275 ),
			new City ( 47708, "Evansville", "Indiana", "IN", "Vanderburgh", 37.9718, -87.572 ),
			new City ( 46802, "Fort Wayne", "Indiana", "IN", "Allen", 41.0707, -85.1543 ),
			new City ( 46206, "Indianapolis", "Indiana", "IN", "Marion", 39.7613, -86.1613 ),
			new City ( 46624, "South Bend", "Indiana", "IN", "St .Joseph", 41.7332, -86.2833 ),
			new City ( 52401, "Cedar Rapids", "Iowa", "IA", "Linn", 41.9743, -91.6554 ),
			new City ( 50318, "Des Moines", "Iowa", "IA", "Polk", 41.6727, -93.5722 ),
			new City ( 66106, "Kansas City", "Kansas", "KS", "Wyandotte", 39.0694, -94.7178 ),
			new City ( 66051, "Olathe", "Kansas", "KS", "Johnson", 38.8999, -94.832 ),
			new City ( 66204, "Shawnee Mission", "Kansas", "KS", "Johnson", 38.9928, -94.6771 ),
			new City ( 66603, "Topeka", "Kansas", "KS", "Shawnee", 39.0553, -95.6802 ),
			new City ( 67276, "Wichita", "Kansas", "KS", "Sedgwick", 37.6936, -97.4804 ),
			new City ( 40511, "Lexington", "Kentucky", "KY", "Fayette", 38.0932, -84.5007 ),
			new City ( 40231, "Louisville", "Kentucky", "KY", "Jefferson", 38.189, -85.6768 ),
			new City ( 70826, "Baton Rouge", "Louisiana", "LA", "East Baton Rouge", 30.5159, -91.0804 ),
			new City ( 70509, "Lafayette", "Louisiana", "LA", "Lafayette", 30.1565, -92 ),
			new City ( 70113, "New Orleans", "Louisiana", "LA", "Orleans", 29.9405, -90.0848 ),
			new City ( 71102, "Shreveport", "Louisiana", "LA", "Caddo", 32.6076, -93.7526 ),
			new City ( 21202, "Baltimore", "Maryland", "MD", "Baltimore", 39.2998, -76.6075 ),
			new City ( 02205, "Boston", "Massachusetts", "MA", "Suffolk", 42.3503, -71.0539 ),
			new City ( 02139, "Cambridge", "Massachusetts", "MA", "Middlesex", 42.3647, -71.1042 ),
			new City ( 01853, "Lowell", "Massachusetts", "MA", "Middlesex", 42.4464, -71.4594 ),
			new City ( 01101, "Springfield", "Massachusetts", "MA", "Hampden", 42.1707, -72.6048 ),
			new City ( 01613, "Worcester", "Massachusetts", "MA", "Worcester", 42.2933, -71.802 ),
			new City ( 48104, "Ann Arbor", "Michigan", "MI", "Washtenaw", 42.2694, -83.7282 ),
			new City ( 48233, "Detroit", "Michigan", "MI", "Wayne", 42.2399, -83.1508 ),
			new City ( 48502, "Flint", "Michigan", "MI", "Genesee", 43.0151, -83.6948 ),
			new City ( 49501, "Grand Rapids", "Michigan", "MI", "Kent", 42.9842, -85.6291 ),
			new City ( 48924, "Lansing", "Michigan", "MI", "Ingham", 42.5992, -84.372 ),
			new City ( 48311, "Sterling Heights", "Michigan", "MI", "Macomb", 42.6723, -82.9031 ),
			new City ( 48090, "Warren", "Michigan", "MI", "Macomb", 42.6723, -82.9031 ),
			new City ( 55401, "Minneapolis", "Minnesota", "MN", "Hennepin", 44.9835, -93.2683 ),
			new City ( 55109, "Saint Paul", "Minnesota", "MN", "Ramsey", 45.0132, -93.0297 ),
			new City ( 39205, "Jackson", "Mississippi", "MS", "Hinds", 32.3113, -90.3972 ),
			new City ( 64052, "Independence", "Missouri", "MO", "Jackson", 39.075, -94.4499 ),
			new City ( 64108, "Kansas City", "Missouri", "MO", "Jackson", 39.0837, -94.5868 ),
			new City ( 65801, "Springfield", "Missouri", "MO", "Greene", 37.2581, -93.3437 ),
			new City ( 63155, "Saint Louis", "Missouri", "MO", "St. Louis", 38.6531, -90.2435 ),
			new City ( 68501, "Lincoln", "Nebraska", "NE", "Lancaster", 40.8651, -96.8231 ),
			new City ( 68108, "Omaha", "Nebraska", "NE", "Douglas", 41.2382, -95.9336 ),
			new City ( 89015, "Henderson", "Nevada", "NV", "Clark", 36.0357, -114.9718 ),
			new City ( 89199, "Las Vegas", "Nevada", "NV", "Clark", 35.9279, -114.9721 ),
			new City ( 89030, "North Las Vegas", "Nevada", "NV", "Clark", 36.2115, -115.1241 ),
			new City ( 89510, "Reno", "Nevada", "NV", "Washoe", 39.7699, -119.6027 ),
			new City ( 03103, "Manchester", "New Hampshire", "NH", "Hillsborough", 42.9656, -71.4493 ),
			new City ( 07208, "Elizabeth", "New Jersey", "NJ", "Union", 40.6747, -74.2239 ),
			new City ( 07302, "Jersey City", "New Jersey", "NJ", "Hudson", 40.7221, -74.0469 ),
			new City ( 07102, "Newark", "New Jersey", "NJ", "Essex", 40.732, -74.1765 ),
			new City ( 07510, "Paterson", "New Jersey", "NJ", "Passaic", 41.0114, -74.3048 ),
			new City ( 87101, "Albuquerque", "New Mexico", "NM", "Bernalillo", 35.1996, -106.6448 ),
			new City ( 14240, "Buffalo", "New York", "NY", "Erie", 42.7684, -78.8871 ),
			new City ( 10199, "New York City", "New York", "NY", "New York", 40.7503, -74.0006 ),
			new City ( 14692, "Rochester", "New York", "NY", "Monroe", 43.286, -77.6843 ),
			new City ( 13220, "Syracuse", "New York", "NY", "Onondaga", 43.1234, -76.1282 ),
			new City ( 10701, "Yonkers", "New York", "NY", "Westchester", 40.9461, -73.8669 ),
			new City ( 27511, "Cary", "North Carolina", "NC", "Wake", 35.7641, -78.7786 ),
			new City ( 28228, "Charlotte", "North Carolina", "NC", "Mecklenburg", 35.26, -80.8042 ),
			new City ( 27701, "Durham", "North Carolina", "NC", "Durham", 35.9967, -78.8966 ),
			new City ( 28302, "Fayetteville", "North Carolina", "NC", "Cumberland", 35.0343, -78.9088 ),
			new City ( 27420, "Greensboro", "North Carolina", "NC", "Guilford", 36.113, -79.7759 ),
			new City ( 27613, "Raleigh", "North Carolina", "NC", "Wake", 35.8949, -78.7051 ),
			new City ( 27102, "Winston Salem", "North Carolina", "NC", "Forsyth", 36.0323, -80.3962 ),
			new City ( 44309, "Akron", "Ohio", "OH", "Summit", 41.0962, -81.5123 ),
			new City ( 45225, "Cincinnati", "Ohio", "OH", "Hamilton", 39.1447, -84.5533 ),
			new City ( 44101, "Cleveland", "Ohio", "OH", "Cuyahoga", 41.5234, -81.5996 ),
			new City ( 43216, "Columbus", "Ohio", "OH", "Franklin", 39.969, -83.0114 ),
			new City ( 45401, "Dayton", "Ohio", "OH", "Montgomery", 39.7505, -84.2686 ),
			new City ( 43601, "Toledo", "Ohio", "OH", "Lucas", 41.7207, -83.5694 ),
			new City ( 73019, "Norman", "Oklahoma", "OK", "Cleveland", 35.2086, -97.4445 ),
			new City ( 73125, "Oklahoma City", "Oklahoma", "OK", "Oklahoma", 35.4654, -97.5218 ),
			new City ( 74107, "Tulsa", "Oklahoma", "OK", "Tulsa", 36.1042, -96.0244 ),
			new City ( 97401, "Eugene", "Oregon", "OR", "Lane", 44.0682, -123.0819 ),
			new City ( 97208, "Portland", "Oregon", "OR", "Multnomah", 45.5322, -122.5648 ),
			new City ( 97309, "Salem", "Oregon", "OR", "Marion", 44.9845, -122.457 ),
			new City ( 18101, "Allentown", "Pennsylvania", "PA", "Lehigh", 40.6026, -75.4691 ),
			new City ( 16515, "Erie", "Pennsylvania", "PA", "Erie", 42.1827, -80.0649 ),
			new City ( 19104, "Philadelphia", "Pennsylvania", "PA", "Philadelphia", 39.9597, -75.2024 ),
			new City ( 15290, "Pittsburgh", "Pennsylvania", "PA", "Allegheny", 40.4344, -80.0248 ),
			new City ( 02904, "Providence", "Rhode Island", "RI", "Providence", 41.8541, -71.4378 ),
			new City ( 29401, "Charleston", "South Carolina", "SC", "Charleston", 32.7795, -79.9371 ),
			new City ( 29201, "Columbia", "South Carolina", "SC", "Richland", 34.0004, -81.0334 ),
			new City ( 57104, "Sioux Falls", "South Dakota", "SD", "Minnehaha", 43.5514, -96.7375 ),
			new City ( 37421, "Chattanooga", "Tennessee", "TN", "Hamilton", 35.025, -85.1459 ),
			new City ( 37043, "Clarksville", "Tennessee", "TN", "Montgomery", 36.5107, -87.2757 ),
			new City ( 37950, "Knoxville", "Tennessee", "TN", "Knox", 35.9901, -83.9622 ),
			new City ( 38101, "Memphis", "Tennessee", "TN", "Shelby", 35.0507, -89.8478 ),
			new City ( 37230, "Nashville", "Tennessee", "TN", "Davidson", 36.1866, -86.7852 ),
			new City ( 79604, "Abilene", "Texas", "TX", "Taylor", 32.4288, -99.7952 ),
			new City ( 79120, "Amarillo", "Texas", "TX", "Potter", 35.1964, -101.8034 ),
			new City ( 76004, "Arlington", "Texas", "TX", "Tarrant", 32.7714, -97.2915 ),
			new City ( 78710, "Austin", "Texas", "TX", "Travis", 30.352, -97.7151 ),
			new City ( 77707, "Beaumont", "Texas", "TX", "Jefferson", 30.0686, -94.1755 ),
			new City ( 78520, "Brownsville", "Texas", "TX", "Cameron", 25.9337, -97.5174 ),
			new City ( 75006, "Carrollton", "Texas", "TX", "Dallas", 32.9657, -96.8825 ),
			new City ( 78469, "Corpus Christi", "Texas", "TX", "Nueces", 27.777, -97.4632 ),
			new City ( 75260, "Dallas", "Texas", "TX", "Dallas", 32.7673, -96.7776 ),
			new City ( 76201, "Denton", "Texas", "TX", "Denton", 33.2289, -97.1314 ),
			new City ( 79910, "El Paso", "Texas", "TX", "El Paso", 31.6948, -106.3 ),
			new City ( 76161, "Fort Worth", "Texas", "TX", "Tarrant", 32.7714, -97.2915 ),
			new City ( 75040, "Garland", "Texas", "TX", "Dallas", 32.9227, -96.6248 ),
			new City ( 75051, "Grand Prairie", "Texas", "TX", "Dallas", 32.7115, -97.0069 ),
			new City ( 77201, "Houston", "Texas", "TX", "Harris", 29.834, -95.4342 ),
			new City ( 75061, "Irving", "Texas", "TX", "Dallas", 32.8267, -96.9633 ),
			new City ( 07977, "Peapack", "New Jersey", "NJ", "Somerset", 40.7079, -74.6541 ),
			new City ( 16541, "Erie", "Pennsylvania", "PA", "Erie", 42.1827, -80.0649 ),
			new City ( 26541, "Maidsville", "West Virginia", "WV", "Monongalia", 39.6584, -80.0288 ),
			new City ( 26601, "Sutton", "West Virginia", "WV", "Braxton", 38.6541, -80.676 ),
			new City ( 36541, "Grand Bay", "Alabama", "AL", "Mobile", 30.4983, -88.3282 ),
			new City ( 52042, "Edgewood", "Iowa", "IA", "Clayton", 42.6541, -91.395 ),
			new City ( 54417, "Brokaw", "Wisconsin", "WI", "Marathon", 45.0274, -89.6541 ),
			new City ( 56541, "Flom", "Minnesota", "MN", "Norman", 47.1588, -96.1309 ),
			new City ( 66541, "Summerfield", "Kansas", "KS", "Marshall", 39.9798, -96.3279 ),
			new City ( 76541, "Killeen", "Texas", "TX", "Bell", 31.1164, -97.7278 ),
			new City ( 79830, "Alpine", "Texas", "TX", "Brewster", 30.2631, -103.6541 ),
			new City ( 78041, "Laredo", "Texas", "TX", "Webb", 27.5569, -99.4907 ),
			new City ( 79402, "Lubbock", "Texas", "TX", "Lubbock", 33.5922, -101.8511 ),
			new City ( 78501, "Mcallen", "Texas", "TX", "Hidalgo", 26.2154, -98.2359 ),
			new City ( 75149, "Mesquite", "Texas", "TX", "Dallas", 32.7678, -96.6082 ),
			new City ( 77501, "Pasadena", "Texas", "TX", "Harris", 29.834, -95.4342 ),
			new City ( 75074, "Plano", "Texas", "TX", "Collin", 33.0277, -96.6777 ),
			new City ( 78284, "San Antonio", "Texas", "TX", "Bexar", 29.4426, -98.4913 ),
			new City ( 76702, "Waco", "Texas", "TX", "McLennan", 31.5475, -97.1443 ),
			new City ( 84199, "Salt Lake City", "Utah", "UT", "Salt Lake", 40.7259, -111.9394 ),
			new City ( 84199, "Salt Lake City", "Utah", "UT", "Salt Lake", 40.7259, -111.9394 ),
			new City ( 22314, "Alexandria", "Virginia", "VA", "Alexandria", 38.806, -77.0529 ),
			new City ( 23320, "Chesapeake", "Virginia", "VA", "Chesapeake", 36.7352, -76.2384 ),
			new City ( 23670, "Hampton", "Virginia", "VA", "Hampton", 37.0727, -76.3899 ),
			new City ( 23607, "Newport News", "Virginia", "VA", "Newport News", 36.9864, -76.4165 ),
			new City ( 23501, "Norfolk", "Virginia", "VA", "Norfolk", 36.8959, -76.2085 ),
			new City ( 23707, "Portsmouth", "Virginia", "VA", "Portsmouth", 36.8362, -76.344 ),
			new City ( 23702, "Portsmouth", "Virginia", "VA", "Portsmouth", 36.8035, -76.327 ),
			new City ( 23232, "Richmond", "Virginia", "VA", "Richmond", 37.5202, -77.4084 ),
			new City ( 23450, "Virginia Beach", "Virginia", "VA", "Virginia Beach", 36.844, -76.1204 ),
			new City ( 98009, "Bellevue", "Washington", "WA", "King", 47.4323, -121.8034 ),
			new City ( 98108, "Seattle", "Washington", "WA", "King", 47.5413, -122.3129 ),
			new City ( 99201, "Spokane", "Washington", "WA", "Spokane", 47.6665, -117.4365 ),
			new City ( 98413, "Tacoma", "Washington", "WA", "Pierce", 47.0662, -122.1132 ),
			new City ( 98668, "Vancouver", "Washington", "WA", "Clark", 45.8016, -122.5203 ),
			new City ( 54303, "Green Bay", "Wisconsin", "WI", "Brown", 44.5522, -88.0788 ),
			new City ( 53714, "Madison", "Wisconsin", "WI", "Dane", 43.0977, -89.3118 ),
			new City ( 53203, "Milwaukee", "Wisconsin", "WI", "Milwaukee", 43.0403, -87.9154 )	
		};
	}
}