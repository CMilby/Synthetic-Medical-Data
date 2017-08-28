﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace MedicalDataGeneration {

	public class PhoneNumber {

		public string AreaCode;
		public string MiddleDigits;
		public string LastDigits;

		public PhoneNumber ( string p_town, Random p_rand ) {
			PopulateDictionary ( );

			int areaCode = 0;
			if ( !AreaCodes.TryGetValue ( p_town, out areaCode ) ) {
				areaCode = 0;
			}
				
			AreaCode = areaCode.ToString ( "D3" );
			MiddleDigits = "555";
			LastDigits = p_rand.Next ( 10000 ).ToString ( "D4" );
		}

		public override string ToString ( ) {
			return "(" + AreaCode + ") " + MiddleDigits + "-" + LastDigits;
		}

		private static Dictionary<string, int> AreaCodes;

		private static void PopulateDictionary ( ) {
			if ( AreaCodes != null ) {
				return;
			}

			AreaCodes = new Dictionary<string, int> {
				{ "Jersey City", 201 },
				{ "Waterbury", 203 },
				{ "New Haven", 203 },
				{ "Bridgeport", 203 },
				{ "Stamford", 203 },
				{ "Montgomery", 205 },
				{ "Selma", 205 },
				{ "Jackson", 205 },
				{ "Seattle", 206 },
				{ "Stockton", 209 },
				{ "Merced", 209 },
				{ "San Antonio", 210 },
				{ "New York", 212 },
				{ "Los Angeles", 213 },
				{ "Dallas", 214 },
				{ "Philadelphia", 215 },
				{ "Cleveland", 216 },
				{ "Springfield", 217 },
				{ "Decatur", 217 },
				{ "Champaign", 217 },
				{ "Duluth", 218 },
				{ "Brainerd", 218 },
				{ "Grand Rapids", 218 },
				{ "International Falls", 218 },
				{ "Fort Wayne", 219 },
				{ "South Bend", 219 },
				{ "Gary", 219 },
				{ "Baton Rouge", 225 },
				{ "New Roads", 225 },
				{ "Gulfport", 228 },
				{ "Pascagoula", 228 },
				{ "Albany", 229 },
				{ "Americus", 229 },
				{ "Bainbridge", 229 },
				{ "Valdosta", 229 },
				{ "Traverse City", 231 },
				{ "Muskegon", 231 },
				{ "Ludington", 231 },
				{ "Akron", 234 },
				{ "Canton", 234 },
				{ "Youngstown", 234 },
				{ "Frederick", 240 },
				{ "Hagerstown", 240 },
				{ "Cumberland", 240 },
				{ "Troy", 248 },
				{ "non-Vancouver area", 250 },
				{ "Greenville", 252 },
				{ "Kitty Hawk", 252 },
				{ "Tacoma", 253 },
				{ "Waco", 254 },
				{ "Killeen", 254 },
				{ "Huntsville", 256 },
				{ "Racine", 262 },
				{ "West Bend", 262 },
				{ "Paducah", 270 },
				{ "Bowling Green", 270 },
				{ "Owensboro", 270 },
				{ "Houston", 281 },
				{ "Denver", 303 },
				{ "Boulder", 303 },
				{ "Miami", 305 },
				{ "Key West", 305 },
				{ "Scottsbluff", 308 },
				{ "North Platte", 308 },
				{ "Moline", 309 },
				{ "Peoria", 309 },
				{ "West Los Angeles", 310 },
				{ "Torrance", 310 },
				{ "Malibu", 310 },
				{ "Chicago", 312 },
				{ "Detroit", 313 },
				{ "Saint Louis", 314 },
				{ "Syracuse", 315 },
				{ "Utica", 315 },
				{ "Watertown", 315 },
				{ "Wichita", 316 },
				{ "Parsons", 316 },
				{ "Great Bend", 316 },
				{ "Indianapolis", 317 },
				{ "Shreveport", 318 },
				{ "Monroe", 318 },
				{ "Alexandria", 318 },
				{ "Dubuque", 319 },
				{ "Davenport", 319 },
				{ "Iowa City", 319 },
				{ "Burlington", 319 },
				{ "Saint Cloud", 320 },
				{ "Morris", 320 },
				{ "Hutchinson", 320 },
				{ "Orlando", 321 },
				{ "Birmingham", 334 },
				{ "Tuscaloosa", 334 },
				{ "Winston Salem", 336 },
				{ "Lafayette", 337 },
				{ "Lake Charles", 337 },
				{ "Bronx", 347 },
				{ "Queens", 347 },
				{ "Brooklyn", 347 },
				{ "Staten Island", 347 },
				{ "Gainesville", 352 },
				{ "Ocala", 352 },
				{ "Olympia", 360 },
				{ "Bellingham", 360 },
				{ "Aberdeen", 360 },
				{ "Corpus Christi", 361 },
				{ "Victoria", 361 },
				{ "Provo", 385 },
				{ "Ogden", 385 },
				{ "Omaha", 402 },
				{ "Lincoln", 402 },
				{ "Calgary", 403 },
				{ "southern portion", 403 },
				{ "Atlanta", 404 },
				{ "Oklahoma City", 405 },
				{ "Edmond", 405 },
				{ "San Jose", 408 },
				{ "Sunnyvale", 408 },
				{ "Los Gatos", 408 },
				{ "Beaumont", 409 },
				{ "Galveston", 409 },
				{ "Baltimore", 410 },
				{ "Cambridge", 410 },
				{ "Pittsburgh", 412 },
				{ "Pittsfield", 413 },
				{ "Milwaukee", 414 },
				{ "San Francisco", 415 },
				{ "Novato", 415 },
				{ "San Rafael", 415 },
				{ "Toronto", 416 },
				{ "Joplin", 417 },
				{ "Quebec", 418 },
				{ "Toledo", 419 },
				{ "Sandusky", 419 },
				{ "Chattanooga", 423 },
				{ "Sweetwater", 423 },
				{ "Bristol", 423 },
				{ "Seattle area", 425 },
				{ "Logan", 435 },
				{ "Blanding", 435 },
				{ "Richfield", 435 },
				{ "Ashtabula", 440 },
				{ "Elyria", 440 },
				{ "Laval", 450 },
				{ "Inbound International", 456 },
				{ "Plano", 469 },
				{ "Macon", 478 },
				{ "Warner Robins", 478 },
				{ "Swainsboro", 478 },
				{ "eastern Phoenix area", 480 },
				{ "Chandler", 480 },
				{ "Allentown", 484 },
				{ "Reading", 484 },
				{ "Personal Communication Service", 500 },
				{ "Little Rock", 501 },
				{ "Fayetteville", 501 },
				{ "Hot Springs", 501 },
				{ "Louisville", 502 },
				{ "Frankfort", 502 },
				{ "Portland", 503 },
				{ "Salem", 503 },
				{ "Tillamoon", 503 },
				{ "Astoria", 503 },
				{ "New Orleans", 504 },
				{ "Houma", 504 },
				{ "Rochester", 507 },
				{ "Mankato", 507 },
				{ "Marshall", 507 },
				{ "Worthington", 507 },
				{ "Worcester", 508 },
				{ "Attleboro", 508 },
				{ "New Bedford", 508 },
				{ "Hyannis", 508 },
				{ "Spokane", 509 },
				{ "Yakima", 509 },
				{ "Walla Walla", 509 },
				{ "Oakland", 510 },
				{ "Hayward", 510 },
				{ "Austin", 512 },
				{ "Cincinnati", 513 },
				{ "Middletown", 513 },
				{ "Montreal", 514 },
				{ "Des Moines", 515 },
				{ "Fort Dodge", 515 },
				{ "Elmont", 516 },
				{ "Lansing", 517 },
				{ "Alpena", 517 },
				{ "Saranac Lake", 518 },
				{ "Plattsburgh", 518 },
				{ "Windsor", 519 },
				{ "London", 519 },
				{ "non-Phoenix areas", 520 },
				{ "Redding", 530 },
				{ "Chico", 530 },
				{ "Alturas", 530 },
				{ "Roanoke", 540 },
				{ "Harrisonburg", 540 },
				{ "Fredricksburg", 540 },
				{ "Winchester", 540 },
				{ "Eugene", 541 },
				{ "Bend", 541 },
				{ "Medford", 541 },
				{ "Burns", 541 },
				{ "Fresno", 559 },
				{ "West Palm Beach", 561 },
				{ "Boca Raton", 561 },
				{ "Long Beach", 562 },
				{ "Scranton", 570 },
				{ "Williamsport", 570 },
				{ "Jefferson City", 573 },
				{ "Hannibal", 573 },
				{ "Enid", 580 },
				{ "Woodward", 580 },
				{ "Lawton", 580 },
				{ "Canadian Services", 600 },
				{ "Mc Comb", 601 },
				{ "Phoenix", 602 },
				{ "Vancouver area", 604 },
				{ "Morehead", 606 },
				{ "Pikeville", 606 },
				{ "Elmira", 607 },
				{ "Binghamton", 607 },
				{ "Madison", 608 },
				{ "La Crosse", 608 },
				{ "Trenton", 609 },
				{ "Atlantic City", 609 },
				{ "Brown Mills", 609 },
				{ "Minneapolis", 612 },
				{ "Ottawa", 613 },
				{ "Columbus", 614 },
				{ "Nashville", 615 },
				{ "Kalamazoo", 616 },
				{ "Boston", 617 },
				{ "Mount Vernon", 618 },
				{ "Carbondale", 618 },
				{ "San Diego", 619 },
				{ "western Phoenix area", 623 },
				{ "Pasadena", 626 },
				{ "Aurora", 630 },
				{ "eastern Long Island", 631 },
				{ "Union", 636 },
				{ "Chesterfield", 636 },
				{ "Mason City", 641 },
				{ "Buckeye", 623 },
				{ "Creston", 641 },
				{ "Palo Alto", 650 },
				{ "San Mateo", 650 },
				{ "Saint Paul", 651 },
				{ "Lindstrom", 651 },
				{ "Red Wing", 651 },
				{ "Sedalia", 660 },
				{ "Bakersfield", 661 },
				{ "Tupelo", 662 },
				{ "Fort Worth", 682 },
				{ "Interexchange Carrier Services", 700 },
				{ "Las Vegas", 702 },
				{ "Charlotte", 704 },
				{ "Kingstown", 704 },
				{ "Sudbury", 705 },
				{ "Sault Ste Marie", 705 },
				{ "Athens", 706 },
				{ "Augusta", 706 },
				{ "Toccoa", 706 },
				{ "Dalton", 706 },
				{ "Rome", 706 },
				{ "Santa Rosa", 707 },
				{ "Ukiah", 707 },
				{ "Eureka", 707 },
				{ "Chicago Heights", 708 },
				{ "US Government", 710 },
				{ "Sioux City", 712 },
				{ "Council Bluffs", 712 },
				{ "Orange", 714 },
				{ "Huntington Beach", 714 },
				{ "Wausau", 715 },
				{ "Eau Claire", 715 },
				{ "Buffalo", 716 },
				{ "Jamestown", 716 },
				{ "Harrisburg", 717 },
				{ "Gettysburg", 717 },
				{ "Colorado Springs", 719 },
				{ "Pueblo", 719 },
				{ "New Castle", 724 },
				{ "Uniontown", 724 },
				{ "Clearwater", 727 },
				{ "Lakewood", 732 },
				{ "New Brunswick", 732 },
				{ "Neptune", 732 },
				{ "Ann Arbor", 734 },
				{ "Lancaster", 740 },
				{ "Marietta", 740 },
				{ "Norfolk", 757 },
				{ "Indio", 760 },
				{ "Ridgecrest", 760 },
				{ "Bishop", 760 },
				{ "Blythe", 760 },
				{ "Maple Grove", 763 },
				{ "Marion", 765 },
				{ "Muncie", 765 },
				{ "Richmond", 765 },
				{ "Roswell", 770 },
				{ "Cedartown", 770 },
				{ "Griffin", 770 },
				{ "Reno", 775 },
				{ "Carson City", 775 },
				{ "Elko", 775 },
				{ "Ely", 775 },
				{ "Tonopah", 775 },
				{ "Edmonton", 780 },
				{ "northern portion", 780 },
				{ "Norwood", 781 },
				{ "Weymouth", 781 },
				{ "Saugus", 781 },
				{ "Topeka", 785 },
				{ "Saline", 785 },
				{ "Toll-Free", 800 },
				{ "Salt Lake City", 801 },
				{ "Columbia", 803 },
				{ "Sumter", 803 },
				{ "Lynchburg", 804 },
				{ "Danville", 804 },
				{ "Thousand Oaks", 805 },
				{ "San Luis Obispo", 805 },
				{ "Lompoc", 805 },
				{ "Amarillo", 806 },
				{ "Lubbock", 806 },
				{ "Thunder Bay", 807 },
				{ "Flint", 810 },
				{ "Port Huron", 810 },
				{ "Terre Haute", 812 },
				{ "Bloomington", 812 },
				{ "New Albany", 812 },
				{ "Evansville", 812 },
				{ "Tampa", 813 },
				{ "Erie", 814 },
				{ "Warren", 814 },
				{ "Altoona", 814 },
				{ "Johnstown", 814 },
				{ "Rickford", 815 },
				{ "Freeport", 815 },
				{ "De Kalb", 815 },
				{ "La Salle", 815 },
				{ "Kansas City", 816 },
				{ "Saint Joseph", 816 },
				{ "Glendale", 818 },
				{ "San Fernando",818 },
				{ "Hull", 819 },
				{ "Sherbrooke", 819 },
				{ "Asheville", 828 },
				{ "Uvalde", 830 },
				{ "Salinas", 831 },
				{ "Santa Cruz", 831 },
				{ "Charleston", 843 },
				{ "Myrtle Beach", 843 },
				{ "Florence", 843 },
				{ "Poughkeepsie", 845 },
				{ "Waukegan", 847 },
				{ "Des Plaines", 847 },
				{ "Tallahassee", 850 },
				{ "Cherry Hill", 856 },
				{ "Vineland", 856 },
				{ "Solano Beach", 858 },
				{ "northern San Diego area", 858 },
				{ "Lexington", 859 },
				{ "Hartford", 860 },
				{ "Norwich", 860 },
				{ "Avon Park", 863 },
				{ "Clewiston", 863 },
				{ "Spartanburg", 864 },
				{ "Anderson", 864 },
				{ "Knoxville", 865 },
				{ "Premium Services", 900 },
				{ "Memphis", 901 },
				{ "Union City", 901 },
				{ "Tyler", 903 },
				{ "Sherman", 903 },
				{ "Hamilton area", 905 },
				{ "Sault Ste. Marie", 906 },
				{ "Escanaba", 906 },
				{ "Marquette", 906 },
				{ "Washington", 908 },
				{ "Pomona", 909 },
				{ "San Bernadino", 909 },
				{ "Temecula", 909 },
				{ "Wilmington", 910 },
				{ "Jacksonville", 910 },
				{ "Waycross", 912 },
				{ "Brunswick", 912 },
				{ "Savannah", 912 },
				{ "Vidalia", 912 },
				{ "Overland Park", 913 },
				{ "White Plains", 914 },
				{ "El Paso", 915 },
				{ "Alpine", 915 },
				{ "Midland", 915 },
				{ "Abilene", 915 },
				{ "Sacramento", 916 },
				{ "Tulsa", 918 },
				{ "Mcalester", 918 },
				{ "Bartlesville", 918 },
				{ "Raleigh", 919 },
				{ "Durham", 919 },
				{ "Green Bay", 920 },
				{ "Oshkosh", 920 },
				{ "Sheboygan", 920 },
				{ "Concord", 925 },
				{ "Pleasanton", 925 },
				{ "Manchester", 931 },
				{ "Clarksville", 931 },
				{ "Cookeville", 931 },
				{ "Lufkin", 936 },
				{ "Dayton", 937 },
				{ "Hillsboro", 937 },
				{ "Vernon", 940 },
				{ "Wichita Falls", 940 },
				{ "Naples", 941 },
				{ "Fort Meyers", 941 },
				{ "Irvine", 949 },
				{ "Laguna Niguel", 949 },
				{ "Fort Lauderdale", 954 },
				{ "Mcallen", 956 },
				{ "Brownsville", 956 },
				{ "Grand Junction", 970 },
				{ "Steamboat Springs", 970 },
				{ "Fort Collins", 970 },
				{ "Paterson", 973 },
				{ "Sussex", 973 },
				{ "Peabody", 978 },
				{ "Fitchburg", 978 },
				{ "Wharton",979 }
			};
		}
	}
}
