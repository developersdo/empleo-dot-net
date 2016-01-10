using System.Data.Entity;
using EmpleoDotNet.Models;
using NSubstitute;
using NUnit.Framework;

namespace EmpleoDotNet.Tests
{
    [TestFixture]
    public class EntityFrameworkUnitOfWorkTest
    {
        private DbContext _context;
        private EntityFrameworkUnitOfWork _sut;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<DbContext>();
            _sut = new EntityFrameworkUnitOfWork(_context);
        }

        [Test]
        public void SaveChanges_CallsDbContextSaveChanges()
        {
            // Act
            _sut.SaveChanges();

            // Assert
            _context.Received(1).SaveChanges();
        }
    }
}