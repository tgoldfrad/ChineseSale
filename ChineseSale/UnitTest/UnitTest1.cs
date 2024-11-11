using ChineseSale.Controllers;
using ChineseSale.Entities;
using ChineseSale.Servers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Phone_ReturnsTrue()
        {
            ErrorType error = 0;
            bool isValid = new DonorsServer().IsValidPhone("05567", out error);
            Assert.False(isValid);
        }
        [Fact]
        public void GetAll_ReturnsCount()
        {
            var controller = new DonorsController();
            var res = controller.Get();
            Assert.Equal(1, res.Value.Count());
        }
        [Fact]
        public void GetById_ReturnsBadRequest()
        {
            var controller = new DonorsController();
            var res = controller.Get(-2);
            Assert.IsType<BadRequestResult>(res.Result);
        }
        [Fact]
        public void Post_ReturnsOk()
        {
            var controller = new DonorsController();
            var res = controller.Post(new Donors() { DonorId = 1, DonorFirstName = "Tamar", DonorLastName = "Levi", DonorAdress = "Bloi", DonorCity = 3, DonorTelephone = "03-5703050", DonorPhone = "0504177668" });
            Assert.IsType<OkObjectResult>(res);
        }
        [Fact]
        public void Put_ReturnsNotFound()
        {
            var controller = new DonorsController();
            var res = controller.Put(2, new Donors() { DonorId = 2, DonorFirstName = "Tamar", DonorLastName = "Levi", DonorAdress = "Bloi", DonorCity = 3, DonorTelephone = "03-5703050", DonorPhone = "0504177668" });
            Assert.IsType<NotFoundResult>(res.Result);
        }
        [Fact]
        public void Delete_ReturnsOK()
        {
            var controller = new DonorsController();
            var res = controller.Delete(2);
            Assert.IsNotType<OkObjectResult>(res);

        }
    }
}