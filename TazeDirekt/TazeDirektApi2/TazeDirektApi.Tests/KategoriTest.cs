using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TazeDirektApi2.Data;
using TazeDirektApi2.Services;

namespace TazeDirektApi.Tests
{
    [TestClass]
    public class KategoriTest
    {
        private IRepository<Kategori> _kategoriRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _kategoriRepository = new Repository<Kategori>();
        }


        [TestMethod]
        public void AddKategori()
        {
            // Arrange
            Kategori kategori = new Kategori
            {
                Adi = "Deneme"    
            };
            // Act
            _kategoriRepository.Insert(kategori);
            // Assert
            Assert.IsTrue(kategori.Id > 0);
        }
        [TestMethod]
        public void GetKategori()
        {  // Arrange
            var kategori = _kategoriRepository.GetById(1);

            // Assert
            Assert.IsNotNull(kategori);
        }
        [TestMethod]
        public void UpdateKategori()
        {
            // Arrange
            var replacedId = 6;
            var newName = "Test1";


            // Act
            var kategori = _kategoriRepository.GetById(replacedId);
            kategori.Adi = newName;
            _kategoriRepository.Update(kategori);
            var urunRetriewAgain = _kategoriRepository.GetById(replacedId);


            // Assert
            Assert.IsNotNull(kategori);
            Assert.AreEqual(urunRetriewAgain.Id, replacedId);
            Assert.AreEqual(urunRetriewAgain.Adi, newName);
        }
        [TestMethod]
        public void DeleteKategori() // hata alınır ise veritabanından belirtilen id silindigi için olabilir.
        {
            // Arrange.
            var urunGetId = 8;

            //Act
            _kategoriRepository.Delete(urunGetId);
            var urunRetriewAgain = _kategoriRepository.GetById(urunGetId);


            //Assert
            Assert.IsNull(urunRetriewAgain);
        }
    }
}
