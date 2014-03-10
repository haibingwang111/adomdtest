using AdomdTests.utils;
using Microsoft.AnalysisServices.AdomdClient;
using NUnit.Framework;
using System;
using System.Collections;
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
            foreach (DictionaryEntry entry in adoConnections)
            {
                AdomdConnection connection = (AdomdConnection)entry.Value;
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
                    Assert.Inconclusive("No connection found for test " +
                                connection.ConnectionString);
            }
        }

        //[Test]
        //[Ignore]
        /*public void FetchPropertyID()
        {
            foreach (DictionaryEntry entry in adoConnections)
            {
                AdomdConnection connection = (AdomdConnection)entry.Value;
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
                    Assert.Inconclusive("No connection found for test " +
                                    connection.ConnectionString);
            }
        }*/

        [Test]
        public void FetchPropertyName()
        {
            foreach (DictionaryEntry entry in adoConnections)
            {
                AdomdConnection connection = (AdomdConnection)entry.Value;
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
                    Assert.Inconclusive("No connection found for test " +
                                    connection.ConnectionString);
            }
        }

        [Test]
        //[Ignore]
        public void FetchPropertyDescription()
        {
            foreach (DictionaryEntry entry in adoConnections)
            {
                AdomdConnection connection = (AdomdConnection)entry.Value;
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
                                            var property = mem.Properties["DESCRIPTION"];
                                            Assert.IsNotNullOrEmpty(property.ToString());

                                            /*String description = mem.Description;
                                            Assert.IsNotNullOrEmpty(description);*/
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
                    Assert.Inconclusive("No connection found for test " +
                                    connection.ConnectionString);
            }
        }

        [Test]
        public void FetchPropertyMemberKey()
        {
            foreach (DictionaryEntry entry in adoConnections)
            {
                AdomdConnection connection = (AdomdConnection)entry.Value;
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
                    Assert.Inconclusive("No connection found for test " +
                                    connection.ConnectionString);
            }
        }


        [Test]
        public void FetchPropertyMemberOrdinal()
        {
            foreach (DictionaryEntry entry in adoConnections)
            {
                AdomdConnection connection = (AdomdConnection)entry.Value;
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
                    Assert.Inconclusive("No connection found for test " +
                                    connection.ConnectionString);
            }
        }

        [Test]
        public void FetchPropertyExpression()
        {
            foreach (DictionaryEntry entry in adoConnections)
            {
                AdomdConnection connection = (AdomdConnection)entry.Value;
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
                    Assert.Inconclusive("No connection found for test " +
                                    connection.ConnectionString);
            }
        }
    }
}
