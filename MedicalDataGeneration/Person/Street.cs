using System;

namespace MedicalDataGeneration {

	public class Street {

		public int StreetNumber;
		public string StreetAddress;

		public Street ( int p_num, string p_address ) {
			StreetNumber = p_num;
			StreetAddress = p_address;
		}

		public override string ToString ( ) {
			return StreetNumber.ToString ( ) + " " + StreetAddress;
		}

		public static Street GenerateStreet ( Random p_rand ) {
			return new Street ( p_rand.Next ( 1, 99999 ), StreetNames [ p_rand.Next ( StreetNames.Length ) ] + " " + StreetSuffixes [ p_rand.Next ( StreetSuffixes.Length ) ] + "." );
		}

		public static Street GenerateObfuscatedStreet ( Random p_rand ) {
			return new Street ( p_rand.Next ( 1, 99999 ), GenerateObfuscated ( p_rand ) + " " + StreetSuffixes [ p_rand.Next ( StreetSuffixes.Length - 1 ) ] + "." );
		}

		private static string GenerateObfuscated ( Random p_rand ) {
			int count = p_rand.Next ( 2, 4 );
			string name = "";

			for ( int i = 0; i < count; i++ ) {
				name += UniqueCharPairs [ p_rand.Next ( UniqueCharPairs.Length - 1 ) ];	
			}

			for ( int i = 0; i < name.Length; i++ ) {
				if ( p_rand.NextDouble ( ) < 0.35 ) {
					name = name.Insert ( i, Vowels [ p_rand.Next ( Vowels.Length - 1 ) ].ToString ( ) );
					i++;
				}
			}

			name = name.ToLower ( );
			return char.ToUpper ( name [ 0 ] ) + name.Substring ( 1 );
		}

		public static char[] Vowels = new char[] {
			'a', 'e', 'i', 'o', 'u'
		};

		public static string[] StreetNames = new string[] {
			"Abbey", "Acacia", "Acacia", "Acadia", "Acevedo", "Acme", "Acorn", "Acton", "Ada", "Adair",
			"Adam", "Addison", "Adele", "Admiral", "Adolph Sutro", "Aerial", "Agnon", "Agua", "Ahern", "Alabama",
			"Aladdin", "Alameda", "Alana", "Albatross", "Alberta", "Albion", "Alder", "Alemany", "Alert", "Alhambra",
			"Alice B Toklas", "Allen", "Allison", "Allston", "Alma", "Almaden", "Aloha", "Alpha", "Alpine", "Alta",
			"Alta Mar", "Alta Vista", "Alton", "Alvarado", "Alviso", "Alvord", "Amador", "Amatista", "Amatury", "Amazon",
			"Amber", "Ambrose Bierce", "Ames", "Amethyst", "Amherst", "Amity", "Anderson", "Andover", "Andrew", "Angelos",
			"Anglo", "Ankeny", "Annapolis", "Annie", "Anson", "Anthony", "Antonio", "Anza", "Anza", "Anzavista",
			"Apollo", "Apparel", "Appleton", "Appleton", "Aptos", "Aquavista", "Arago", "Arballo", "Arbol", "Arbor",
			"Arch", "Arco", "Ardath", "Ardenwood", "Arelious Walker", "Arellano", "Argent", "Argonaut", "Arguello", "Arkansas",
			"Arleta", "Arlington", "Armistead", "Armory", "Armstrong", "Arnold", "Arroyo", "Arthur", "Ash", "Ashburton",
			"Ashbury", "Ashbury", "Ashton", "Ashwood", "Aspen", "Atalaya", "Athens", "Atoll", "Attridge", "Auburn",
			"August", "Augusta", "Austin", "Auto", "Automobile", "Avalon", "Avila", "Avoca", "Avocet", "Avon",
			"Aztec", "Bache", "Bacon", "Baden", "Badger", "Baker", "Baker", "Balance", "Balboa", "Balceta",
			"Baldwin", "Balhi", "Balmy", "Baltimore", "Banbury", "Bancroft", "Bank", "Banks", "Bannan", "Banneker",
			"Bannock", "Barcelona", "Barnard", "Barneveld", "Barry", "Bartlett", "Bartol", "Bass", "Battery", "Baxter",
			"Bay", "Bay Shore", "Bay View", "Bayside", "Bayside Village", "Bayview", "Bayview Park", "Baywood", "Beach", "Beachmont",
			"Beacon", "Beale", "Beatrice", "Beaumont", "Beaver", "Beckett", "Bedford", "Beeman", "Behr", "Beideman",
			"Belcher", "Belden", "Belgrave", "Bell", "Bella Vista", "Bellair", "Belle", "Belles", "Bellevue", "Belmont",
			"Belvedere", "Bemis", "Bengal", "Bennington", "Benton", "Bepler", "Bergen", "Berkeley", "Berkshire", "Bernal Heights",
			"Bernard", "Bernice", "Bernice Rodgers", "Berry", "Berry Extension", "Bertha", "Bertie Minor", "Bertita", "Berwick", "Bessie",
			"Beulah", "Beverly", "Bigelow", "Bigler", "Birch", "Birchwood", "Bird", "Birmingham", "Bishop", "Bitting",
			"Black", "Blackstone", "Blair", "Blairwood", "Blake", "Blanche", "Blandy", "Blanken", "Blatchford", "Bliss",
			"Bliss", "Bluxome", "Blythdale", "Boalt", "Boardman", "Bob Kaufman", "Bocana", "Bonifacio", "Bonita", "Bonnie Brae",
			"Bonview", "Borica", "Bosworth", "Boutwell", "Bowdoin", "Bowley", "Bowley", "Bowling Green", "Bowman", "Boyd",
			"Boylston", "Boynton", "Bradford", "Brady", "Brannan", "Brant", "Brazil", "Breen", "Brentwood", "Bret Harte",
			"Brewster", "Brice", "Bridgeview", "Bridgeview", "Bright", "Brighton", "Britton", "Broad", "Broadmoor", "Bromley",
			"Brompton", "Bronte", "Brook", "Brookdale", "Brookhaven", "Brooklyn", "Brooks", "Brosnan", "Brotherhood", "Brown",
			"Bruce", "Brumiss", "Brunswick", "Brush", "Brush", "Brussels", "Bryant", "Bucareli", "Buchanan", "Buckingham",
			"Buena Vista", "Buena Vista", "Buena Vista", "Burgoyne", "Burke", "Burlwood", "Burnett", "Burnett", "Burns", "Burnside",
			"Burr", "Burritt", "Burrows", "Burrows", "Bush", "Butte", "Byron", "Byxbee", "Cabrillo", "Cadell",
			"Caine", "Caire", "Caledonia", "Calgary", "Calhoun", "California", "California", "Calvert", "Cambon", "Cambridge",
			"Camellia", "Cameo", "Cameron", "Camp", "Campbell", "Campton", "Campus", "Campus", "Canby", "Canby",
			"Candlestick Cove", "Capistrano", "Capitol", "Capp", "Capra", "Card", "Cardenas", "Cargo", "Carl", "Carmel",
			"Carmelita", "Carnelian", "Carolina", "Carpenter", "Carr", "Carrie", "Carrizal", "Carroll", "Carson", "Carter",
			"Carver", "Casa", "Cascade", "Case", "Caselli", "Cashmere", "Casitas", "Cassandra", "Castelo", "Castenada",
			"Castillo", "Castle", "Castle Manor", "Castro", "Catalina", "Catherine", "Cayuga", "Cedar", "Cedro", "Central",
			"Central Magazine", "Century", "Ceres", "Cerritos", "Cervantes", "Cesar Chavez", "Chabot", "Chain Of Lakes", "Chancery", "Chapman",
			"Charles", "Charlton", "Charter Oak", "Chase", "Chatham", "Chattanooga", "Chaves", "Chenery", "Cherry", "Chesley",
			"Chester", "Chestnut", "Chicago", "Child", "Chilton", "China Basin", "Chinook", "Christmas Tree Point", "Christopher", "Chula",
			"Chumasero", "Church", "Circular", "Cityview", "Clairview", "Clara", "Claremont", "Clarence", "Clarendon", "Clarion",
			"Clarke", "Clarke", "Clarkson", "Claude", "Clay", "Clayton", "Clearfield", "Clearview", "Cleary", "Clement",
			"Clementina", "Cleo Rand", "Cleveland", "Clifford", "Clinton", "Clipper", "Clipper", "Clipper Cove", "Cloud", "Clover",
			"Clover", "Clyde", "Cochrane", "Codman", "Cohen", "Colby", "Cole", "Coleman", "Coleridge", "Colin",
			"Colin P Kelly Jr", "Colleen", "College", "College", "Collingwood", "Collins", "Colon", "Colonial", "Colton", "Columbus",
			"Colusa", "Comerford", "Commer", "Commercial", "Commonwealth", "Compton", "Concord", "Concourse", "Congdon", "Congo",
			"Conkling", "Connecticut", "Conrad", "Conservatory", "Constanso", "Continuum", "Converse", "Cook", "Cooper", "Copper",
			"Cora", "Coral", "Coral", "Coralino", "Corbett", "Corbin", "Cordelia", "Cordova", "Cornwall", "Corona",
			"Coronado", "Cortes", "Cortland", "Corwin", "Cosgrove", "Cosmo", "Coso", "Costa", "Cottage", "Cotter",
			"Country Club", "Coventry", "Coventry", "Cowell", "Cowles", "Cragmont", "Crags", "Craig", "Crane", "Cranleigh",
			"Craut", "Crescent", "Crescent", "Crescent", "Crescio", "Crespi", "Cresta Vista", "Crestlake", "Crestline", "Crestmont",
			"Crestwell", "Crisp", "Crissy Field", "Croaker", "Crook", "Cross", "Crossover", "Crown", "Crown", "Crystal",
			"Cuba", "Cuesta", "Culebra", "Cumberland", "Cunningham", "Curtis", "Cushman", "Custer", "Custom House", "Cutler",
			"Cuvier", "Cypress", "Cyril Magnin", "Cyrus", "Daggett", "Dakota", "Dalewood", "Daniel Burnham", "Danton", "Danvers",
			"Darien", "Darrell", "Dartmouth", "Dashiell Hammett", "Davenport", "Davidson", "Davis", "Davis", "Dawnview", "Dawson",
			"Day", "Dearborn", "Decatur", "Decker", "Dedman", "Deems", "Dehon", "Del Monte", "Del Sur", "Del Vale",
			"Delancey", "Delano", "Delaware", "Delgado", "Dellbrook", "Delmar", "Delta", "Deming", "Denslowe", "Derby",
			"Desmond", "Detroit", "Devonshire", "Dewey", "Dewitt", "Diamond", "Diamond Cove", "Diamond Heights", "Diana", "Diaz",
			"Dicha", "Dichiera", "Dickinson", "Digby", "Dirk Dirksen", "Divisadero", "Division", "Dixie", "Dock", "Dodge",
			"Dolores", "Dolores", "Dolphin", "Don Chee", "Donahue", "Donner", "Dorado", "Dorantes", "Dorcas", "Dorchester",
			"Dore", "Doric", "Dorland", "Dorman", "Dormitory", "Double Rock", "Douglass", "Dove", "Dow", "Downey",
			"Dr Carlton B Goodlett", "Drake", "Drumm", "Drummond", "Dublin", "Duboce", "Dudley", "Dukes", "Duncan", "Duncombe",
			"Dunnes", "Dunshee", "Dunsmuir", "Dwight", "Eagle", "Earl", "East Beach", "East Crystal Cove", "East Fort Miley", "Eastman",
			"Eastwood", "Eaton", "Ecker", "Eddy", "Edgar", "Edgardo", "Edgehill", "Edgewood", "Edie", "Edinburgh",
			"Edith", "Edna", "Edward", "Egbert", "El Mirasol", "El Plazuela", "El Polin", "El Sereno", "El Verano", "Eldridge",
			"Elgin", "Elim", "Elizabeth", "Elk", "Ellert", "Ellington", "Elliot", "Ellis", "Ellsworth", "Elm",
			"Elmhurst", "Elmira", "Elmwood", "Elsie", "Elwood", "Emerald", "Emerald Cove", "Emerson", "Emery", "Emil",
			"Emma", "Emmett", "Encanto", "Encinal", "Encline", "English", "Enterprise", "Entrada", "Erie", "Erkson",
			"Ervine", "Escolta", "Escondido", "Esmeralda", "Espanola", "Esquina", "Essex", "Estero", "Eucalyptus", "Euclid",
			"Eugenia", "Eureka", "Evans", "Eve", "Evelyn", "Everglade", "Everson", "Ewer", "Ewing", "Excelsior",
			"Exchange", "Executive Park", "Exeter", "Exposition", "Fair", "Fair Oaks", "Fairbanks", "Fairfax", "Fairfield", "Fairmount",
			"Faith", "Fallon", "Falmouth", "Fanning", "Farallones", "Fargo", "Farnsworth", "Farnum", "Farragut", "Farview",
			"Fauntleroy", "Faxon", "Federal", "Felix", "Fell", "Fella", "Felton", "Fenton", "Fern", "Fernandez",
			"Fernwood", "Fielding", "Fifth", "Filbert", "Fillmore", "Finley", "First", "First", "Fisher", "Fisher",
			"Fisher", "Fitch", "Fitzgerald", "Flint", "Flood", "Flora", "Florence", "Florentine", "Florida", "Flounder",
			"Flournoy", "Flower", "Foerster", "Folsom", "Font", "Fontinella", "Foote", "Ford", "Forest", "Forest Hill",
			"Forest Knolls", "Forest Side", "Forest View", "Forsyth", "Fort Funston", "Fountain", "Fowler", "France", "Francis", "Francisco",
			"Franconia", "Frank Norris", "Franklin", "Fratessa", "Fredela", "Frederick", "Fredson", "Freelon", "Freeman", "Fremont",
			"French", "Fresnel", "Fresno", "Friedell", "Friendship", "Front", "Fuente", "Fulton", "Funston", "Funston",
			"Gabilan", "Gaiser", "Galewood", "Galilee", "Galindo", "Gallagher", "Galvez", "Gambier", "Garces", "Garcia",
			"Garden", "Garden", "Gardener", "Gardenside", "Garfield", "Garlington", "Garnett", "Garrison", "Gates", "Gateview",
			"Gaven", "Gaviota", "Geary", "Geary", "Gellert", "Gene Friend", "Genebern", "General Kennedy", "Geneva", "Gennessee",
			"Genoa", "George", "Georgia", "Gerke", "Germania", "Getz", "Gibb", "Gibbon", "Gilbert", "Gillette",
			"Gilman", "Gilroy", "Girard", "Girard", "Gladeview", "Gladiolus", "Gladstone", "Gladys", "Glen", "Glenbrook",
			"Glendale", "Glenhaven", "Glenview", "Globe", "Gloria", "Glover", "Godeus", "Goethe", "Goettingen", "Gold",
			"Gold Mine", "Goldberg", "Golden", "Golden Gate", "Golding", "Goleta", "Gonzalez", "Gordon", "Gorgas", "Gorham",
			"Gough", "Gould", "Grace", "Grafton", "Graham", "Granada", "Grand View", "Grand View", "Grant", "Granville",
			"Grattan", "Graystone", "Great", "Greely", "Green", "Greenough", "Greenview", "Greenwich", "Greenwood", "Grenard",
			"Griffith", "Grijalva", "Grote", "Grove", "Guerrero", "Guttenberg", "Guy", "H", "Habitat", "Hahn",
			"Haight", "Hale", "Halibut", "Hallam", "Halleck", "Halyburton", "Hamerton", "Hamilton", "Hamlin", "Hampshire",
			"Hancock", "Hangah", "Hanover", "Harbor", "Hardie", "Hardie", "Harding", "Hare", "Harkness", "Harlan",
			"Harlem", "Harlow", "Harney", "Harold", "Harper", "Harriet", "Harriet", "Harrington", "Harris", "Harrison",
			"Harrison", "Harry", "Hartford", "Harvard", "Hastings", "Hattie", "Havelock", "Havens", "Havenside", "Hawes",
			"Hawkins", "Hawthorne", "Hayes", "Hays", "Hayward", "Hazelwood", "Head", "Healy", "Hearst", "Heather",
			"Helen", "Helena", "Hemlock", "Hemway", "Henry", "Henry Adams", "Heritage", "Hermann", "Hernandez", "Heron",
			"Hester", "Heyman", "Hickory", "Hicks", "Hidalgo", "High", "Highland", "Higuera", "Hiliritas", "Hill",
			"Hill", "Hill Point", "Hillcrest", "Hillcrest", "Hillside", "Hillview", "Hillway", "Hilton", "Himmelmann", "Hitchcock",
			"Hitchcock", "Hobart", "Hodges", "Hoff", "Hoffman", "Hoffman", "Holladay", "Holland", "Hollis", "Hollister",
			"Holloway", "Holly Park", "Hollywood", "Holyoke", "Homer", "Homestead", "Homewood", "Hooker", "Hooper", "Hopkins",
			"Horace", "Horne", "Hotaling", "Houston", "Howard", "Howard", "Howard", "Howth", "Hubbell", "Hudson",
			"Hugo", "Hulbert", "Humboldt", "Hunt", "Hunter", "Hunter", "Hunters Point", "Hunters Point", "Huntington", "Huron",
			"Hussey", "Hutchins", "Idora", "Ignacio", "Illinois", "Ils", "Imperial", "Ina", "Inca", "Incinerator",
			"India", "Indiana", "Industrial", "Infantry", "Ingalls", "Ingerson", "Ingleside", "Innes", "Innes", "Inverness",
			"Iowa", "Iris", "Iron", "Ironwood", "Irving", "Irwin", "Isadora Duncan", "Isis", "Islais", "Isola",
			"Issleib", "Italy", "Ivy", "Jack Balestreri", "Jack Kerouac", "Jack London", "Jack Micheline", "Jackson", "Jade", "Jakey",
			"James", "Jamestown", "Jansen", "Jarboe", "Jason", "Jasper", "Jauss", "Java", "Jean", "Jefferson",
			"Jennifer", "Jennings", "Jennings", "Jerome", "Jerrold", "Jersey", "Jessie", "Jessie East", "Jessie West", "Jewett",
			"John", "John F Kennedy", "John F Shelley", "John Maher", "John Muir", "Johnstone", "Joice", "Jones", "Joost", "Jordan",
			"Jose Sarria", "Josepha", "Josiah", "Joy", "Juan Bautista", "Juanita", "Judah", "Judson", "Jules", "Julia",
			"Julian", "Julius", "Junior", "Juniper", "Junipero Serra", "Juri", "Justin", "Kalmanovitz", "Kamille", "Kansas",
			"Kaplan", "Karen", "Kate", "Kearny", "Kearny", "Keith", "Kelloch", "Kempton", "Kendall", "Kennedy",
			"Kenneth Rexroth", "Kenny", "Kensington", "Kent", "Kenwood", "Keppler", "Kern", "Key", "Keyes", "Keyes",
			"Keystone", "Kezar", "Kimball", "King", "Kingston", "Kinzey", "Kirkham", "Kirkwood", "Kiska", "Kissling",
			"Kittredge", "Knockash", "Knollview", "Knott", "Kobbe", "Kohler", "Koret", "Kramer", "Krausgrill", "Kronquist",
			"La Ferrera", "La Grande", "Lafayette", "Laguna", "Laguna Honda", "Lagunitas", "Laidley", "Lake", "Lake Forest", "Lake Merced",
			"Lake Merced Hill", "Lakeshore", "Lakeshore", "Lakeview", "Lakewood", "Lamartine", "Lamson", "Lancaster", "Landers", "Lane",
			"Langdon", "Langton", "Lansdale", "Lansing", "Lapham", "Lapidge", "Larkin", "Las Villas", "Laskie", "Lassen",
			"Lathrop", "Latona", "Laura", "Laurel", "Lauren", "Laussat", "Lawrence", "Lawton", "Le Conte", "Le Conte",
			"Leavenworth", "Ledyard", "Lee", "Leese", "Legion", "Legion Of Honor", "Leidesdorff", "Leland", "Lendrum", "Lenox",
			"Leo", "Leona", "Leroy", "Lessing", "Lester", "Letterman", "Levant", "Lexington", "Liberty", "Lick",
			"Liebig", "Liggett", "Lilac", "Lillian", "Lily", "Linares", "Lincoln", "Lincoln", "Lincoln", "Linda",
			"Linda Vista", "Linden", "Lindsay", "Lippard", "Lisbon", "Littlefield", "Livingston", "Lloyd", "Lobos", "Locksley",
			"Lockwood", "Locust", "Loehr", "Lois", "Loma Vista", "Lombard", "Lomita", "London", "Lone Mountain", "Long",
			"Long Bridge", "Longview", "Loomis", "Lopez", "Loraine", "Lori", "Los Palmos", "Lottie Bennett", "Louisburg", "Louisiana",
			"Lowell", "Lower", "Lower Fort Mason", "Loyola", "Lucerne", "Lucky", "Lucy", "Ludlow", "Lulu", "Lunado",
			"Lunado", "Lundeen", "Lundys", "Lupine", "Lurline", "Lurmont", "Lusk", "Lydia", "Lyell", "Lynch",
			"Lyndhurst", "Lyon", "Lysette", "Mabel", "Mabini", "Mabrey", "Macalla", "Macalla", "Macarthur", "Macedonia",
			"Macondray", "Maddux", "Madera", "Madison", "Madrid", "Madrone", "Magellan", "Magnolia", "Mahan", "Maiden",
			"Majestic", "Malden", "Mallorca", "Malta", "Malvina", "Manchester", "Mandalay", "Mangels",
			"Manor", "Manseau", "Mansell", "Mansfield", "Manzanita", "Maple", "Marcela", "Marcy", "Marengo", "Margaret",
			"Margrave", "Marietta", "Marin", "Marina", "Marina Green", "Marine", "Mariner", "Marion", "Mariposa", "Marist",
			"Mark", "Mark Twain", "Market", "Marlin", "Marne", "Mars", "Marshall", "Marsily", "Marston", "Martha",
			"Martin Luther King Jr", "Martinez", "Marvel", "Marview", "Mary", "Mary Teresa", "Maryland", "Mason", "Mason", "Masonic",
			"Massachusetts", "Massasoit", "Mateo", "Matthew", "Mauldin", "Maxwell", "Mayfair", "Mayflower", "Maynard", "Maywood",
			"Mcallister", "Mccann", "Mccarthy", "Mccoppin", "Mccormick", "Mcdonald", "Mcdowell", "Mckinley", "Mckinnon", "Mclaren",
			"Mclea", "Mcnair", "Mcrae", "Mcrae", "Meacham", "Meade", "Meadowbrook", "Meda", "Medau", "Medical Center",
			"Megan", "Melba", "Melra", "Melrose", "Mendell", "Mendosa", "Menoher", "Mercato", "Merced", "Mercedes",
			"Merchant", "Merchant", "Mercury", "Merlin", "Merriam", "Merrie", "Merrill", "Merrimac", "Merritt", "Mersey",
			"Mesa", "Mesa", "Metson", "Michigan", "Midcrest", "Middle Point", "Middle West", "Middlefield", "Midway", "Miguel",
			"Milan", "Miles", "Miles", "Miley", "Mill", "Miller", "Miller", "Milton", "Milton I Ross", "Minerva",
			"Minna", "Minnesota", "Mint", "Mint", "Mirabel", "Miraloma", "Miramar", "Mirando", "Mission", "Mission Bay",
			"Mission Rock", "Mississippi", "Missouri", "Mistral", "Mizpah", "Modoc", "Moffitt", "Mojave", "Molimo", "Moncada",
			"Moneta", "Moneta", "Mono", "Montague", "Montalvo", "Montana", "Montcalm", "Montclair", "Monte Vista", "Montecito",
			"Monterey", "Montezuma", "Montgomery", "Monticello", "Monument", "Moore", "Moore", "Moraga", "Moraga", "Moreland",
			"Morgan", "Morningside", "Morrell", "Morrell", "Morris", "Morse", "Morton", "Moscow", "Moss", "Moulton",
			"Moultrie", "Mount", "Mount Vernon", "Mountain Spring", "Mountview", "Muir", "Muir", "Mulford", "Mullen", "Munich",
			"Murray", "Murray", "Museum", "Myra", "Myrtle", "Nadell", "Naglee", "Nahua", "Nancy Pelosi", "Nantucket",
			"Napier", "Naples", "Napoleon", "Natick", "Natoma", "Nauman", "Nautilus", "Navajo", "Navy", "Naylor",
			"Nebraska", "Nellie", "Nelson", "Nelson Rising", "Neptune", "Nevada", "New Montgomery", "Newburg", "Newcomb", "Newell",
			"Newhall", "Newman", "Newton", "Ney", "Niagara", "Niantic", "Nibbi", "Nichols", "Nido", "Nimitz",
			"Nimitz", "Nimitz", "Nob Hill", "Nobles", "Noe", "Nordhoff", "Norfolk", "Noriega", "Normandie", "North",
			"North Hughes", "North Point", "North Van Horn", "North View", "Northgate", "Northpoint", "Northridge", "Northwood", "Norton", "Norwich",
			"Nottingham", "Nueva", "Oak", "Oak Grove", "Oak Park", "Oakdale", "Oakhurst", "Oakwood", "Ocean", "Oceanview",
			"Octavia", "Ofarrell", "Ogden", "Ohlone", "Old Chinatown", "Old Mason", "Olive", "Oliver", "Olmstead", "Olney",
			"Oloran", "Olympia", "Olympic Country Club", "Omar", "Oneida", "Onique", "Onondaga", "Opal", "Opalo", "Ophir",
			"Ora", "Orange", "Orben", "Ord", "Ord", "Ordway", "Oreilly", "Oriole", "Orizaba", "Orsi",
			"Ortega", "Ortega", "Osage", "Oscar", "Osceola", "Osgood", "Oshaughnessy", "Otega", "Otis", "Otsego",
			"Ottawa", "Otter Cove", "Overlook", "Owen", "Owens", "Oxford", "Ozbourn", "Pacheco", "Pacific", "Page",
			"Pagoda", "Palm", "Palmetto", "Palo Alto", "Paloma", "Palos", "Palou", "Panama", "Panorama", "Paradise",
			"Paraiso", "Paramount", "Paris", "Park", "Park", "Park Hill", "Park Presidio", "Parker", "Parkhurst", "Parkridge",
			"Parnassus", "Parque", "Parsons", "Pasadena", "Patten", "Patterson", "Patton", "Patton", "Paul", "Paulding",
			"Payson", "Peabody", "Pearl", "Peek", "Pelican Cove", "Pelton", "Pemberton", "Pena", "Peninsula", "Pennington",
			"Pennsylvania", "Penny", "Peralta", "Perasto", "Perego", "Perimeter", "Perine", "Perry", "Pershing", "Persia",
			"Peru", "Peter Yorke", "Peters", "Petrarch", "Pfeiffer", "Phelan", "Phelps", "Phoenix", "Pico", "Piedmont",
			"Pierce", "Pierpoint", "Pilgrim", "Pinar", "Pine", "Pinehurst", "Pink", "Pino", "Pinto", "Pioche",
			"Piper", "Pixley", "Pizarro", "Plaza", "Pleasant", "Plum", "Plymouth", "Point Lobos", "Polaris", "Polk",
			"Pollard", "Pollock", "Pomona", "Pond", "Pontiac", "Pope", "Pope", "Pope", "Poplar", "Poppy",
			"Portal", "Portal", "Porter", "Portola", "Portola", "Post", "Potomac", "Potrero", "Powell", "Powers",
			"Powhattan", "Prado", "Prague", "Pratt", "Precita", "Prentiss", "Prescott", "Presidio", "Presidio", "Presidio",
			"Pretor", "Priest", "Princeton", "Progress", "Prospect", "Prosper", "Public", "Pueblo", "Pulaski", "Putnam",
			"Quane", "Quarry", "Quartz", "Quebec", "Quesada", "Quickstep", "Quincy", "Quint", "Quintara",
			"Raccoon", "Racine", "Radio", "Rae", "Raleigh", "Ralston", "Ralston", "Ramona", "Ramsel", "Ramsell",
			"Randall", "Randolph", "Rankin", "Rausch", "Ravenwood", "Rawles", "Rayburn", "Raycliff", "Raymond", "Reardon",
			"Rebecca", "Recycle", "Red Leaf", "Red Rock", "Reddy", "Redfield", "Redondo", "Redwood", "Reed", "Reeves",
			"Regent", "Reno", "Reposa", "Reservoir", "Restani", "Restani", "Retiro", "Reuel", "Revere", "Rex",
			"Rey", "Rhine", "Rhode Island", "Rice", "Richard Henry Dana", "Richards", "Richardson", "Richland", "Richter", "Rickard",
			"Rico", "Ridge", "Ridge", "Ridgewood", "Riley", "Rincon", "Ringold", "Rio", "Rio Verde", "Ripley",
			"Ritch", "Rivas", "Rivera", "Riverton", "Rivoli", "Rizal", "Roach", "Roanoke", "Robblee", "Robert C Levy",
			"Robert Kirk", "Robinhood", "Robinson", "Robinson", "Rock", "Rockaway", "Rockdale", "Rockland", "Rockridge", "Rockwood",
			"Rod", "Rodgers", "Rodriguez", "Roemer", "Rolph", "Romain", "Rome", "Romolo", "Rondel", "Roosevelt",
			"Rosa Parks", "Roscoe", "Rose", "Rosella", "Roselyn", "Rosemary", "Rosemont", "Rosenkranz", "Rosewood", "Rosie Lee",
			"Ross", "Rossi", "Rossmoor", "Rotteck", "Rousseau", "Royal", "Ruckman", "Rudden", "Ruger", "Russ",
			"Russell", "Russia", "Russian Hill", "Ruth", "Rutland", "Rutledge", "Sabin", "Sacramento", "Saddleback", "Sadowa",
			"Safira", "Sagamore", "Saint Charles", "Saint Croix", "Saint Elmo", "Saint Francis", "Saint Francis", "Saint George", "Saint Germain", "Saint Josephs",
			"Saint Louis", "Saint Marys", "Sal", "Sala", "Salinas", "Salmon", "Samoset", "Sampson", "San Aleso", "San Andreas",
			"San Anselmo", "San Antonio", "San Benito", "San Bruno", "San Buenaventura", "San Carlos", "San Diego", "San Felipe", "San Fernando", "San Gabriel",
			"San Jacinto", "San Jose", "San Juan", "San Leandro", "San Lorenzo", "San Luis", "San Marcos", "San Miguel", "San Pablo", "San Rafael",
			"San Ramon", "Sanches", "Sanchez", "Sandpiper Cove", "Sansome", "Santa Ana", "Santa Barbara", "Santa Clara", "Santa Cruz", "Santa Fe",
			"Santa Marina", "Santa Monica", "Santa Paula", "Santa Rita", "Santa Rosa", "Santa Ynez", "Santa Ysabel", "Santiago", "Santos", "Sargent",
			"Saroyan", "Saturn", "Saul", "Sawyer", "Scenic", "Schofield", "Schofield", "School", "Schwerin", "Science",
			"Scotia", "Scotland", "Scott", "Scott", "Sea View", "Seacliff", "Seal Cove", "Seal Rock", "Sears", "Seawell",
			"Second", "Security Pacific", "Selby", "Selma", "Seminole", "Seneca", "Sequoia", "Sergeant John V Young", "Serrano", "Service",
			"Severn", "Seville", "Seward", "Seymour", "Shafter", "Shafter", "Shakespeare", "Shannon", "Sharon", "Sharp",
			"Shaw", "Shawnee", "Sheldon", "Shephard", "Sheridan", "Sheridan", "Sherman", "Sherman", "Sherwood", "Shields",
			"Ship", "Shipley", "Shore View", "Short", "Shotwell", "Shoup", "Shrader", "Sibert", "Sibert", "Sibley",
			"Sickles", "Sierra", "Signal", "Silliman", "Silver", "Silverview", "Simonds", "Sixth", "Skyline", "Skyview",
			"Sloan", "Sloat", "Smith", "Sola", "Somerset", "Sonoma", "Sonora", "Sotelo", "Soule", "South",
			"South", "South Gate", "South Hill", "South Hughes", "South Van Ness", "Southard", "Southern Heights", "Southwood", "Sparrow", "Sparta",
			"Spear", "Spear", "Spencer", "Spofford", "Spreckels Lake", "Spring", "Springfield", "Sproule", "Spruce", "Standish",
			"Stanford", "Stanford Heights", "Stanley", "Stanton", "Stanyan", "Stanyan", "Staples", "Stark", "Starr King", "Starview",
			"State", "States", "Steiner", "Sterling", "Stern Grove", "Sternberg", "Steuart", "Steuben", "Steveloe", "Stevenson",
			"Still", "Stillings", "Stillman", "Stilwell", "Stockton", "Stockton", "Stone", "Stonecrest", "Stoneman", "Stoneridge",
			"Stoneybrook", "Stoneyford", "Storey", "Storrie", "Stow Lake", "Stratford", "Striped Bass", "Sturgeon", "Summit", "Summit",
			"Sumner", "Sumner", "Sunbeam", "Sunglow", "Sunnydale", "Sunnyside", "Sunrise", "Sunset", "Sunview", "Surrey",
			"Sussex", "Sutro Heights", "Sutter", "Sweeny", "Swiss", "Sycamore", "Sydney", "Sylvan", "Taber", "Tacoma",
			"Talbert", "Talbert", "Tamalpais", "Tampa", "Tara", "Taraval", "Taylor", "Taylor", "Teddy", "Tehama",
			"Telegraph", "Telegraph Hill", "Temescal", "Temple", "Tennessee", "Tenny", "Teresita", "Terra Vista", "Terrace", "Terrace",
			"Terry A Francois", "Tevis", "Texas", "Thomas", "Thomas", "Thomas Mellon", "Thomas Mellon", "Thomas More", "Thor", "Thornburg",
			"Thorne", "Thornton", "Thorp", "Thrift", "Tiffany", "Tillman", "Tingley", "Tioga", "Tocoloma", "Todd",
			"Toland", "Toledo", "Tompkins", "Tonquin", "Topaz", "Topeka", "Torney", "Torrens", "Touchard", "Towerside",
			"Townsend", "Toyon", "Trader Vic", "Trainor", "Treasure Island", "Treasury", "Treat", "Treat", "Treat", "Trenton",
			"Trinity", "Troy", "Truby", "Truett", "Trumbull", "Tubbs", "Tucker", "Tulane", "Tulare", "Tulip",
			"Tunnel", "Turk", "Turk", "Turk Murphy", "Turner", "Turquoise", "Tuscany", "Twin Peaks", "Ulloa", "Underwood",
			"Union", "United Nations", "University", "Upper", "Upper Service", "Upton", "Upton", "Uranus", "Urbano", "Utah",
			"Valdez", "Vale", "Valencia", "Valerton", "Vallejo", "Valletta", "Valley", "Valmar", "Valparaiso", "Van Buren",
			"Van Dyke", "Van Keuren", "Van Ness", "Vandewater", "Vara", "Varela", "Varennes", "Varney", "Vasquez", "Vassar",
			"Vega", "Velasco", "Venard", "Ventura", "Venus", "Ver Mehr", "Verdi", "Verdun", "Vermont", "Verna",
			"Vernon", "Vesta", "Veterans", "Vicksburg", "Victoria", "Vidal", "Vienna", "Villa", "Vine", "Vinton",
			"Virgil", "Virginia", "Visitacion", "Vista", "Vista", "Vista Verde", "Vista View", "Von Schmidt", "Vulcan", "Wabash",
			"Wagner", "Waithman", "Walbridge", "Waldo", "Walker", "Wallace", "Wallen", "Waller", "Walnut", "Walter",
			"Walter U Lum", "Waltham", "Wanda", "Ward", "Ware", "Warner", "Warren", "Washburn", "Washington", "Washington",
			"Watchman", "Water", "Waterloo", "Waterville", "Watt", "Wattson", "Waverly", "Wawona", "Wayland", "Wayne",
			"Webb", "Webster", "Wedemeyer", "Weldon", "Welsh", "Wentworth", "West", "West Crystal Cove", "West Halleck", "West Pacific",
			"West Point", "West Portal", "West View", "Westbrook", "Western Shore", "Westgate", "Westmoorland", "Weston", "Westside", "Westwood",
			"Wetmore", "Wheat", "Wheeler", "Whipple", "White", "Whitecliff", "Whitfield", "Whiting", "Whiting", "Whitney",
			"Whitney Young", "Whittier", "Wiese", "Wilde", "Wilder", "Wildwood", "Willard", "Willard", "Williams", "Williar",
			"Willie B Kennedy", "Willow", "Wills", "Wilmot", "Wilson", "Winding", "Windsor", "Winfield", "Winn", "Winston",
			"Winter", "Winthrop", "Wisconsin", "Wisser", "Wood", "Woodacre", "Woodhaven", "Woodland", "Woodside", "Woodward",
			"Wool", "Wool", "Woolsey", "Worcester", "Worden", "Worth", "Wright", "Wright", "Wright", "Wyman",
			"Wyton", "Yacht", "Yale", "Yerba Buena", "Yerba Buena", "Yerba Buena", "Yorba", "York", "Yosemite", "Young",
			"Young", "Yukon", "Zampa", "Zanowitz", "Zanowitz", "Zeno", "Zircon", "Zoe", "Zoo", "Dr Tom Waddell",
			"Al Scoma", "Palace"
		};

		public static string[] StreetSuffixes = new string[] {
			"AVE",
			"BLVD",
			"CTR",
			"CT",
			"DR",
			"LN",
			"PL",
			"RD",
			"ST"
		};

		private static string[] UniqueCharPairs = new string[] {
			"bx", "cj", "cv", "cx", "dx", "fq", "fx", "gq", "gx", "hx", "jc", 
			"jf", "jg", "jq", "js", "jv", "jw", "jx", "jz", "kq", "kx", "mx", 
			"px", "pz", "qb", "qc", "qd", "qf", "qg", "qh", "qj", "qk", "ql", 
			"qm", "qn", "qp", "qs", "qt", "qv", "qw", "qx", "qy", "qz", "sx", 
			"vb", "vf", "vh", "vj", "vm", "vp", "vq", "vt", "vw", "vx", "wx", 
			"xj", "xx", "zj", "zq", "zx"
		};
	}
}

