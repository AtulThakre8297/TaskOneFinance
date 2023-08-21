using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskOneFinance.Context;
using TaskOneFinance.Models;


namespace TaskOneFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly ProductDbContext _productDbcontext;
        readonly IMapper _mapper;
        public UserController(ProductDbContext productDbcontext, IMapper mapper)
        {
            _productDbcontext = productDbcontext;
            _mapper = mapper;   
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            User user = _mapper.Map<User>(register);
            var error = await _productDbcontext.Users.AddAsync(user);
            int result = await _productDbcontext.SaveChangesAsync();
            if (result <= 0)
            {


                return BadRequest(error);
            }
            return Ok();
        }



        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            User? user = await _productDbcontext.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user != null)
            {
                if (user.Password == login.Password)
                {
                    return Ok(true);
                }
            }
            return BadRequest(false);
        }

    }
}
