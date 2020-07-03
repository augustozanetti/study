using System;
using interest.Controllers;
using Xunit;

namespace InterestTests
{
    public class Interest
    {
        [Fact]
        public void Get_Interest_Rate_Success()
        {
            var interest = new InterestController();

            var result = interest.Get();

            Assert.Equal(result, 0.01);
        }
    }
}
