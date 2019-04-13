using Dal.Model;
using Dal.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;


namespace UnitTests
{
    [TestClass]
    public class RepositoriesTest
    {
        private GamerRepository gamerRepository { get; set; }
        private Gamer gamer { get; set; }

        public void Setup()
        {
            gamerRepository = new GamerRepository();
            gamer = new Gamer() { Id = 22, Name = "Lsw" };
        }

        [TestMethod]
        public void SaveGamerInGamerRepository()
        {
            Setup();
            gamerRepository.Save(gamer);
            var path = Path.Combine(gamerRepository.AppPath, gamerRepository.FolderName, $"{gamer.Id}.json");
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void GetGamerFromGamerRepository()
        {
            Setup();
            var model = gamerRepository.Get(gamer.Id);
            Assert.IsTrue(gamer.GetType() == model.GetType());
        }
    }
}
