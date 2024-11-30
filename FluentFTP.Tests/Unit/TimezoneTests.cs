﻿using FluentFTP.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace FluentFTP.Tests.Unit {
	public class TimezoneTests {

		[Fact]
		public void FranceToUTC() {

			using (var client = new FtpClient("localhost", "user", "pass")) {

				// input date = 19/Feb/2020 20:30 (8:30 PM) in France

				// convert to UTC (France to UTC)
				AssertConvertedDateTime(client, FtpDate.UTC, "Romance Standard Time", "Europe/Paris", "20200219203000", "19-Feb-2020 6:30:00 PM");
			}
		}
		[Fact]
		public void FranceToLocal() {
			using (var client = new FtpClient("localhost", "user", "pass")) {

				// input date = 19/Feb/2020 20:30 (8:30 PM) in France

				// convert to local time (France to Mumbai)
				AssertConvertedDateTime(client, FtpDate.LocalTime, "Romance Standard Time", "Europe/Paris", "20200219203000", "20-Feb-2020 0:00:00");

			}
		}

		[Fact]
		public void TokyoToUTC() {

			using (var client = new FtpClient("localhost", "user", "pass")) {

				// input date = 19/Feb/2020 00:00 (12 am) in Tokyo

				// convert to UTC (Tokyo to UTC)
				AssertConvertedDateTime(client, FtpDate.UTC, "Tokyo Standard Time", "Asia/Tokyo", "20200219000000", "18-Feb-2020 3:00:00 PM");
			}
		}
		[Fact]
		public void TokyoToLocal() {
			using (var client = new FtpClient("localhost", "user", "pass")) {

				// input date = 19/Feb/2020 00:00 (12 am) in Tokyo

				// convert to local time (Tokyo to Mumbai)
				AssertConvertedDateTime(client, FtpDate.LocalTime, "Tokyo Standard Time", "Asia/Tokyo", "20200219000000", "18-Feb-2020 8:30:00 PM");

			}
		}

		private static void AssertConvertedDateTime(FtpClient client, FtpDate conversion, string winTZ, string unixTZ, string input, string expected) {
			client.Config.TimeConversion = conversion;

			client.Config.SetServerTimeZone(winTZ, unixTZ);
			client.Config.SetClientTimeZone("Tokyo Standard Time", "Asia/Tokyo");

			var result = client.ConvertDate(input.ParseFtpDate(client));

			Assert.Equal(result, DateTime.Parse(expected));
		}
	}
}