using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDataGeneration.Clinic {

	public class DateGeneratorColumn : MultivalueColumn {

		public enum eDateGeneratorColumns {
			LAST_SIGNING_DATE_TIME,
			ENTER_DEPT_DATE_TIME,
			ORDERED_FOR_DATE_TIME,
			FIRST_READING_DATE_TIME,
			BEGIN_PROCEDURE_DATE_TIME,
			ORIGINAL_ORDERED_ON_DATE_TIME,
			END_PROCEDURE_DATE_TIME,
			ORDERED_ON_DATE_TIME,
			LEFT_DEPT_DATE_TIME,
			FIRST_ADDENDUM_DATE_TIME
		}

		private static DateTime StartDate = new DateTime ( 1960, 1, 1 );
		private static DateTime EndDate = new DateTime ( 1995, 1, 1 );

		private DateTime CheckIn;

		public DateGeneratorColumn ( Random p_random, DateTime p_checkIn ) : base ( p_random ) {
			CheckIn = p_checkIn;
			PopulateHeaders ( ); 
		}

		public DateGeneratorColumn ( Random p_random ) : base ( p_random ) {
			CheckIn = GetRandomDay ( );
			PopulateHeaders ( );
		}

		private void PopulateHeaders ( ) {
			HeaderMapper.Add ( "LAST_SIGNING_DATE_TIME", GetLastSigningDateTime );
			HeaderMapper.Add ( "ENTER_DEPT_DATE_TIME", GetEnterDeptDateTime );
			HeaderMapper.Add ( "ORDERED_FOR_DATE_TIME", GetOrderedForDateTime );
			HeaderMapper.Add ( "FIRST_READING_DATE_TIME", GetFirstReadingDateTime );
			HeaderMapper.Add ( "BEGIN_PROCEDURE_DATE_TIME", GetBeginProcedureDateTime );
			HeaderMapper.Add ( "ORIGINAL_ORDERED_ON_DATE_TIME", GetOriginalOrderedDateTime );
			HeaderMapper.Add ( "END_PROCEDURE_DATE_TIME", GetEndProcedureDateTime );
			HeaderMapper.Add ( "ORDERED_ON_DATE_TIME", GetOrderedOnDateTime );
			HeaderMapper.Add ( "LEFT_DEPT_DATE_TIME", GetLeftDeptDateTime );
			HeaderMapper.Add ( "FIRST_ADDENDUM_DATE_TIME", GetFirstAddendumDateTime );
		}

		private ConstantColumn GetFirstAddendumDateTime ( ) {
			return new ConstantColumn ( "FirstAddendumDateTime", AddRandomMinutes ( 300, 420 ).ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetLeftDeptDateTime() {
			return new ConstantColumn ( "LeftDeptDateTime", AddRandomHours ( 5, 7 ).ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetLastSigningDateTime ( ) {
			return new ConstantColumn ( "LastSigningDateTime", AddRandomHours ( 4, 5 ).ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetEnterDeptDateTime() {
			return new ConstantColumn ( "EnterDeptartmentDateTime", CheckIn.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetOrderedForDateTime() {
			return new ConstantColumn ( "OrderedForDateTime", AddRandomHours ( 12, 24 ).ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetFirstReadingDateTime() {
			return new ConstantColumn ( "FirstReadingDateTime", AddRandomMinutes ( 45, 60 ).ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetBeginProcedureDateTime() {
			return new ConstantColumn ( "BeginProcedureDateTime", AddRandomMinutes ( 20, 35 ).ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetOriginalOrderedDateTime() {
			return new ConstantColumn ( "OriginalOrderedDateTime", AddRandomHours ( 5, 9 ).ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetEndProcedureDateTime() {
			return new ConstantColumn ( "EndProcedureDateTime", AddRandomHours ( 3, 7 ).ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetOrderedOnDateTime() {
			return new ConstantColumn ( "OrderedOnDateTime", AddRandomHours ( 7, 8 ).ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		public Column this [ eDateGeneratorColumns p_column ] {
			get {
				return HeaderMapper [ p_column.ToString ( ) ] ( );
			}
		}

		private DateTime GetRandomDay ( ) {
			return StartDate.AddDays ( Random.Next ( EndDate.Subtract ( StartDate ).Days ) );
		}

		private DateTime AddRandomHours ( int p_min, int p_max ) {
			return CheckIn.AddHours ( Random.Next ( p_min, p_max ) );
		}

		private DateTime AddRandomMinutes ( int p_min, int p_max ) {
			return CheckIn.AddSeconds ( Random.Next ( p_min, p_max ) );
		}
	}
}
