using System;

using MedicalDataGeneration.DecisionGraphs;

namespace MedicalDataGeneration {

	class MainClass {

		public static void Main ( string[] args ) {
			/*int numLines = 5000;
			string myPath = "C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\data.csv";
			new SyntheticDataGenerator ( numLines, myPath, 
				new DataInjector ( 1500, eRiskFactor.HEAVY_DRINKER ), 
				new DataInjector ( 1500, eRiskFactor.HEAVY_SMOKER ), 
				new DataInjector ( 1500, eRiskFactor.HEAVY_SMOKER, eRiskFactor.HEAVY_DRINKER ) );
			new SyntheticDataGenerator ( numLines, myPath, new DataInjector ( 10000, 145, 55 ) );*/

			new GraphDataGenerator ( 
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\DecisionGraphs\\SimpleDisease.xml", 
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Simple_Each.csv", 
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Simple_Each_Key.key", 
				eGraphGenertorType.GENERATOR_TYPE_EACH,
				p_seed: 1234,
				p_columns: new ePrintColumns [ ] { ePrintColumns.COLUMN_INCREMENTAL_ID, ePrintColumns.COLUMN_AGE, ePrintColumns.COLUMN_DISORDERS } );
			Console.WriteLine ( "Generated Each" );

			new GraphDataGenerator (
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\DecisionGraphs\\SimpleDisease.xml",
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Simple_Random_100.csv",
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Simple_Random_100_Key.key",
				eGraphGenertorType.GENERATOR_TYPE_RANDOM,
				p_numLines: 100,
				p_seed: 1234,
				p_columns: new ePrintColumns [ ] { ePrintColumns.COLUMN_INCREMENTAL_ID, ePrintColumns.COLUMN_AGE, ePrintColumns.COLUMN_DISORDERS } );
			Console.WriteLine ( "Generated Random 100" );

			new GraphDataGenerator (
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\DecisionGraphs\\SimpleDisease.xml",
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Simple_Random_100000.csv",
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Simple_Random_100000_Key.key",
				eGraphGenertorType.GENERATOR_TYPE_RANDOM,
				p_numLines: 100000,
				p_seed: 1234,
				p_columns: new ePrintColumns [ ] { ePrintColumns.COLUMN_INCREMENTAL_ID, ePrintColumns.COLUMN_AGE, ePrintColumns.COLUMN_DISORDERS } );
			Console.WriteLine ( "Generated Random 100000" );

			/*new GraphDataGenerator ( 
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\DecisionGraphs\\DiseaseGraph.xml", 
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Each.csv", 
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Each_Key.key", 
				eGraphGenertorType.GENERATOR_TYPE_EACH,
				p_seed: 1234 );
			Console.WriteLine ( "Generated Each" );

			new GraphDataGenerator (
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\DecisionGraphs\\DiseaseGraph.xml",
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Random_100.csv",
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Random_100_Key.key",
				eGraphGenertorType.GENERATOR_TYPE_RANDOM,
				p_numLines: 100,
				p_seed: 1234 );
			Console.WriteLine ( "Generated Random 100" );

			new GraphDataGenerator (
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\DecisionGraphs\\DiseaseGraph.xml",
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Random_100000.csv",
				"C:\\Users\\Craig\\Documents\\Projects\\Synthetic-Medical-Data\\Data\\Data_Random_100000_Key.key",
				eGraphGenertorType.GENERATOR_TYPE_RANDOM,
				p_numLines: 100000,
				p_seed: 1234 );
			Console.WriteLine ( "Generated Random 100000" );
			*/

			Console.ReadLine ( );
		}
	}
}