using NUnit.Framework;
using MySql.Data.MySqlClient;
using System.Data;

namespace Physics.UnitTests
{
    [TestFixture]
    public class DBTests
    {
        private DB db;

        [SetUp]
        public void Setup()
        {
            db = new DB();
        }

        [Test]
        public void TestOpenConnection()
        {
            db.openConnection();
            Assert.AreEqual(ConnectionState.Open, db.getConnection().State);
            db.closeConnection();
        }

        [Test]
        public void TestCloseConnection()
        {
            db.openConnection();
            db.closeConnection();
            Assert.AreEqual(ConnectionState.Closed, db.getConnection().State);
        }

        [Test]
        public void TestIsConnectionOpen()
        {
            db.openConnection();
            Assert.IsTrue(db.IsConnectionOpen());
            db.closeConnection();
        }


        [Test]
        public void TestLogin_IncorrectCredentials()
        {
            // Создаем временного пользователя для теста
            string username = "testuser";
            string password = "testpassword";

            // Проверяем вход с неправильными учетными данными
            Assert.IsFalse(db.Login(username, password));
        }
    }
}
