using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helpers;

namespace UniversityAppTests
{
	[TestClass]
	public sealed class AssemblyUnitTestShared
	{
		[AssemblyInitialize]
		public static void ClassStartInitialize(TestContext testContext)
		{
			UnitTestHelpers.Start("APIUniversitytestinstance", new string[] { "APIUniversity" });
			UnitTestHelpers.CreateAllTables(DummyDataLayer.APIUniversityTables.TableList, DummyDataLayer.APIUniversityTables.DatabaseName);
		}

		[AssemblyCleanup]
		public static void ClassEndCleanup()
		{
			UnitTestHelpers.End();
		}
	}
}
