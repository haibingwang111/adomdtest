using AdomdTests.utils;
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
        public PropertiesTests()
        {
            Properties prop = new Properties("connection.properties");
            String fetchStr = prop.get("fetchProperties");

            fetchProperties = !fetchStr.Equals("All")?Int32.Parse(fetchStr):-1;
        }

        private int fetchProperties;

        [Test]
        public void FetchAllProperties()
        {
            int count = 0;

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
                                    count++;
                                    try
                                    {
                                        mem.FetchAllProperties();
                                        Assert.IsTrue(true);
                                        if (count == fetchProperties)
                                            return;
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
                                        var property = mem.Properties["ID"];
                                        Assert.IsNotNullOrEmpty(property.ToString());
                                        return;
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
        public void IntrinsicPropertyName()
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
                                        String name = mem.Name;
                                        Assert.IsNotNullOrEmpty(name);
                                        return;
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
        public void IntrinsicPropertyDescription()
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
                                        String description = mem.Description;
                                        Assert.IsNotNullOrEmpty(description);
                                        return;
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
        public void FetchPropertyMemberKey()
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
                                        var property = mem.Properties["MEMBER_KEY"];
                                        Assert.IsNotNullOrEmpty(property.ToString());
                                        return;
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
        public void FetchPropertyMemberOrdinal()
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
                                        var property = mem.Properties["MEMBER_ORDINAL"];
                                        Assert.IsNotNullOrEmpty(property.ToString());
                                        return;
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
        public void FetchPropertyExpression()
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
                                        var property = mem.Properties["EXPRESSION"];
                                        Assert.IsNotNullOrEmpty(property.ToString());
                                        return;
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
    }
}
