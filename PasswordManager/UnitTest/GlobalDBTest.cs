﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{

    [TestClass]
    public class GlobalDBTest
    {
        [TestMethod]
        public void TestDatabaseInitialization()
        {
            Database database = GlobalDb.db;

            Assert.IsNotNull(database);
        }
    }
}
