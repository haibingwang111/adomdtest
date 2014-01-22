using Microsoft.AnalysisServices.AdomdClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
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
            if (connection != null && connection.State != ConnectionState.Closed)
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
            else
                Assert.Inconclusive("No connection found for test");
        }

        [Test]
        [Ignore]
        public void FetchPropertyID()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
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
            else
                Assert.Inconclusive("No connection found for test");
        }

        [Test]
        public void IntrinsicPropertyName()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                try
                {
                    Member mbr = connection.Cubes["SteelWheelsSales"].Dimensions["Time"].Hierarchies["Time"].Levels["Years"].GetMembers()["2003"];

                    String name = mbr.Name;

                    Assert.IsNotNullOrEmpty(name);
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.ToString());
                }
            }
            else
                Assert.Inconclusive("No connection found for test");
        }

        [Test]
        [Ignore]
        public void IntrinsicPropertyDescription()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                try
                {
                    Member mbr = connection.Cubes["SteelWheelsSales"].Dimensions["Time"].Hierarchies["Time"].Levels["Years"].GetMembers()["2003"];

                    String description = mbr.Description;

                    Assert.IsNotNullOrEmpty(description);
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.ToString());
                }
            }
            else
                Assert.Inconclusive("No connection found for test");
        }

        [Test]
        public void FetchPropertyMemberKey()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
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
            else
                Assert.Inconclusive("No connection found for test");
        }


        [Test]
        public void FetchPropertyMemberOrdinal()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
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
            else
                Assert.Inconclusive("No connection found for test");
        }

        [Test]
        public void FetchPropertyExpression()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
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
            else
                Assert.Inconclusive("No connection found for test");
        }
    }
}
