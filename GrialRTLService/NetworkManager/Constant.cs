using System;

namespace GrialRTLService
{
	public class Constant
	{
		/////////////////// API URL /////////////////////////
		public const string BASE_URL = "http://pnews.mofa.gov.qa/api/";

		public const string SUB_URL_GET_NEWS_LIST =				BASE_URL + "PublicNews/";
		public const string SUB_URL_GET_NEWS_DETAIL =	 		BASE_URL + "";

		public static string ImageUploadURL = BASE_URL;


		/////////////////// MESSAGE /////////////////////////
		public const string FAILED_URL_MESSAGE = "We can't access Server's URL";
		public const string TIMEOUT_ERROR = "Timeout Error";

	}
}
