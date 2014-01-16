using Microsoft.AnalysisServices.AdomdClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdomdTests
{
    [TestFixture]
    public class PropertiesTests : ConnectionTest
    {
        [Test]
        public void FetchAllProperties()
        {
            foreach (var cube in connection.Cubes)
            {
                var dims = cube.Dimensions;
                foreach (var dim in dims)
                {
                    var hies = dim.Hierarchies;
                    foreach (var hie in hies)
                    {
                        var lvls = hie.Levels;
                        foreach (var lvl in lvls)
                        {
                            var mems = lvl.GetMembers(0, 2);
                            foreach (var mem in mems)
                            {
                                try
                                {
                                    mem.FetchAllProperties();
                                    Assert.IsTrue(true);
                                }
                                catch (Exception ex)
                                {
                                    Assert.Fail(ex.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        [Test]
        [Ignore]
        public void FetchPropertyID()
        {
            try
            {
                Member mbr = connection.Cubes["SteelWheelsSales"].Dimensions["Time"].Hierarchies["Time"].Levels["Years"].GetMembers()["2003"];
                mbr.FetchAllProperties();
                var property = mbr.Properties["ID"];
                Assert.IsNotNullOrEmpty(property.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        [Ignore]
        public void FetchPropertyName()
        {
            try
            {
                Member mbr = connection.Cubes["SteelWheelsSales"].Dimensions["Time"].Hierarchies["Time"].Levels["Years"].GetMembers()["2003"];
                mbr.FetchAllProperties();
                var property = mbr.Properties["NAME"];
                Assert.IsNotNullOrEmpty(property.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        public void FetchPropertyMemberKey()
        {
            try
            {
                Member mbr = connection.Cubes["SteelWheelsSales"].Dimensions["Time"].Hierarchies["Time"].Levels["Years"].GetMembers()["2003"];
                mbr.FetchAllProperties();
                var property = mbr.Properties["MEMBER_KEY"];
                Assert.IsNotNullOrEmpty(property.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }


        [Test]
        public void FetchPropertyMemberOrdinal()
        {
            try
            {
                Member mbr = connection.Cubes["SteelWheelsSales"].Dimensions["Time"].Hierarchies["Time"].Levels["Years"].GetMembers()["2003"];
                mbr.FetchAllProperties();
                var property = mbr.Properties["MEMBER_ORDINAL"];
                Assert.IsNotNullOrEmpty(property.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        /*[Ignore]*/
        public void FetchPropertyExpression()
        {
            try
            {
                Member mbr = connection.Cubes["SteelWheelsSales"].Dimensions["Time"].Hierarchies["Time"].Levels["Years"].GetMembers()["2003"];
                mbr.FetchAllProperties();
                var property = mbr.Properties["EXPRESSION"];
                Assert.IsNotNullOrEmpty(property.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
