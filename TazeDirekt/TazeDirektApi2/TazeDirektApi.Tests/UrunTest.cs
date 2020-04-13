using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TazeDirektApi2.Data;
using TazeDirektApi2.Services;

namespace TazeDirektApi.Tests
{
    [TestClass]
    public class UrunTest
    {
        private IRepository<Urun> _urunRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _urunRepository = new Repository<Urun>();
        }


        [TestMethod]
        public void AddUrun()
        {
            // Arrange
            Urun urun = new Urun
            {
                Adi = "Deneme",
                Aciklama = "Deneme Aciklama",
                Fiyat = 12,
                AnalizliMi = true,
                OrganikMi = true,
                KategoriId = 1,
                ResimYolu = null,
                SekersizMi = true,
                TedarikciId = 1,
                YerliUretimMi = false

            };
            // Act
            _urunRepository.Insert(urun);
            // Assert
            Assert.IsTrue(urun.Id > 0);
        }



        [TestMethod]
        public void GetUrun()
        {  // Arrange
            var urun = _urunRepository.GetById(1);

            // Assert
            Assert.IsNotNull(urun);
        }



        [TestMethod]
        public void UpdateUrun()
        {
            // Arrange
            var replacedId = 6;
            var newName = "Test1";


            // Act
            var urun = _urunRepository.GetById(replacedId);
            urun.Adi = newName;
            _urunRepository.Update(urun);
            var urunRetriewAgain = _urunRepository.GetById(replacedId);


            // Assert
            Assert.IsNotNull(urun);
            Assert.IsNotNull(urunRetriewAgain);
            Assert.AreEqual(urunRetriewAgain.Id, replacedId);
            Assert.AreEqual(urunRetriewAgain.Adi, newName);
        }





        [TestMethod]
        public void DeleteUrun() // hata alınır ise veritabanından belirtilen id silindigi için olabilir.
        {
            // Arrange.
            var urunGetId = 8;  

            //Act
            _urunRepository.Delete(urunGetId);
            var urunRetriewAgain = _urunRepository.GetById(urunGetId);

                        //Assert
            Assert.IsNull(urunRetriewAgain);
        }
    }
}
