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
			FIRST_ADDENDUM_DATE_TIME,
			FIRST_SIGN_DATE_TIME
		}

		private static DateTime StartDate = new DateTime ( 1960, 1, 1 );
		private static DateTime EndDate = new DateTime ( 1995, 1, 1 );

		private DateTime OriginalOrder;
		private DateTime OrderOn;
		private DateTime OrderFor;

		private DateTime EnterDept;
		private DateTime BeginProc;
		private DateTime EndProce;
		private DateTime LeaveDept;

		private DateTime FirstRead;
		private DateTime FirstSign;
		private DateTime FirstAddend;
		private DateTime LastSign;

		public DateGeneratorColumn ( Random p_random, DateTime p_checkIn ) : base ( p_random ) {
			CreateTimes ( p_checkIn );
			PopulateHeaders ( ); 
		}

		public DateGeneratorColumn ( Random p_random ) : base ( p_random ) {
			CreateTimes ( GetRandomDay ( ) );
			PopulateHeaders ( );
		}

		private void CreateTimes ( DateTime p_time ) {
			OriginalOrder = p_time;
			OrderOn = p_time;
			OrderFor = p_time;

			EnterDept = AddRandomMinutes ( p_time, 10, 20 );
			BeginProc = AddRandomMinutes ( EnterDept, 5, 30 );
			EndProce = AddRandomMinutes ( BeginProc, 30, 160 );
			LeaveDept = AddRandomMinutes ( EndProce, 1, 10 );

			FirstRead = AddRandomMinutes ( LeaveDept, 15, 1000 );
			FirstSign = AddRandomMinutes ( FirstRead, 1, 1000 );
			FirstAddend = AddRandomMinutes ( FirstSign, 1, 1000 );
			LastSign = AddRandomMinutes ( FirstAddend, 1, 1000 );
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
			HeaderMapper.Add ( "FIRST_SIGN_DATE_TIME", GetFistSigningDateTime );
		}

		private ConstantColumn GetFistSigningDateTime ( ) {
			return new ConstantColumn ( "FirstSigningDateTime", FirstSign.ToString ( "yyyy-MM-dd HH:mm" ) );
		}
		
		private ConstantColumn GetFirstAddendumDateTime ( ) {
			return new ConstantColumn ( "FirstAddendumDateTime", FirstAddend.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetLeftDeptDateTime() {
			return new ConstantColumn ( "LeftDeptDateTime", LeaveDept.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetLastSigningDateTime ( ) {
			return new ConstantColumn ( "LastSigningDateTime", LastSign.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetEnterDeptDateTime() {
			return new ConstantColumn ( "EnterDeptartmentDateTime", EnterDept.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetOrderedForDateTime() {
			return new ConstantColumn ( "OrderedForDateTime", OrderFor.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetFirstReadingDateTime() {
			return new ConstantColumn ( "FirstReadingDateTime", FirstRead.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetBeginProcedureDateTime() {
			return new ConstantColumn ( "BeginProcedureDateTime", BeginProc.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetOriginalOrderedDateTime() {
			return new ConstantColumn ( "OriginalOrderedDateTime", OriginalOrder.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetEndProcedureDateTime() {
			return new ConstantColumn ( "EndProcedureDateTime", EndProce.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		private ConstantColumn GetOrderedOnDateTime() {
			return new ConstantColumn ( "OrderedOnDateTime", OrderOn.ToString ( "yyyy-MM-dd HH:mm" ) );
		}

		public Column this [ eDateGeneratorColumns p_column ] {
			get {
				return HeaderMapper [ p_column.ToString ( ) ] ( );
			}
		}

		private DateTime GetRandomDay ( ) {
			return StartDate.AddDays ( Random.Next ( EndDate.Subtract ( StartDate ).Days ) );
		}

		private DateTime AddRandomMinutes ( DateTime p_time, int p_min, int p_max ) {
			return p_time.AddMinutes ( Random.Next ( p_min, p_max ) );
		}

		private DateTime AddRandomHours ( DateTime p_time, int p_min, int p_max ) {
			return p_time.AddHours ( Random.Next ( p_min, p_max ) );
		}
	}
}
