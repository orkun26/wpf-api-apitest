using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TazeDirektApi2.Data;
using TazeDirektApi2.Services;

namespace TazeDirektApi.Tests
{
    [TestClass]
    public class TedarikciTest
    {
        private IRepository<Tedarikci> _tedarikciRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _tedarikciRepository = new Repository<Tedarikci>();
        }


        [TestMethod]
        public void AddTedarikci()
        {
            // Arrange
            Tedarikci ted = new Tedarikci
            {
                Adi = "Deneme",
                Aciklama = "Deneme Aciklama"
            };
            // Act
            _tedarikciRepository.Insert(ted);
            // Assert
            Assert.IsTrue(ted.Id > 0);
        }
        [TestMethod]
        public void GetTedarikci()
        {  // Arrange
            var urun = _tedarikciRepository.GetById(1);

            // Assert
            Assert.IsNotNull(urun);
        }
        [TestMethod]
        public void UpdateTedarikci()
        {
            // Arrange
            var replacedId = 6;
            var newName = "Test1";


            // Act
            var urun = _tedarikciRepository.GetById(replacedId);
            urun.Adi = newName;
            _tedarikciRepository.Update(urun);
            var urunRetriewAgain = _tedarikciRepository.GetById(replacedId);


            // Assert
            Assert.IsNotNull(urun);
            Assert.AreEqual(urunRetriewAgain.Id, replacedId);
            Assert.AreEqual(urunRetriewAgain.Adi, newName);
        }
        [TestMethod]
        public void DeleteTedarikci() // hata alınır ise veritabanından belirtilen id silindigi için olabilir.
        {
            // Arrange.
            var urunGetId = 8;

            //Act
            _tedarikciRepository.Delete(urunGetId);
            var urunRetriewAgain = _tedarikciRepository.GetById(urunGetId);


            //Assert
            Assert.IsNull(urunRetriewAgain);
        }
    }
}
