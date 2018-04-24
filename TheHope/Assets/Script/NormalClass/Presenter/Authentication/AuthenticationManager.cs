using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthenticationManager : IAuthenticationManager
{
    public void ChangePassword(string newPassword)
    {
        // đăng nhập thành công vào game rồi mới cho đổi
    }

    public void LoginWithFB()
    {
        // xử lý code đăng nhập facebook
        // nếu đây là user mới thì chuyển scene sang màn hình điền thông tin user và gọi setupUserInfo
        // còn không thì
        LoginSuccess();
    }

    public void LoginWithGS(string email, string password)
    {
        // nếu thành công
        LoginSuccess();
    }

    // tự tạo thêm mấy phương thức như vầy chứ đừng có code chung ở trên kia luôn
    private void LoginSuccess() {

    }

    private void LoginFailed() {

    }

    private void RegisterFailed() {
    }

    public void Register(string email, string password)
    {
        // nếu đăng ký thành công thì chuyển scene sang màn hình điền thông tin user
        // và gọi setupUserInfo
    }

    public void ResetPassword(string email, string token, string newPassword)
    {
        // copy token và gửi lên gs cùng với newPassword
        throw new System.NotImplementedException();
    }

    public void SendEmailToken(string email)
    {
        // lần 1 gửi token qua email
        throw new System.NotImplementedException();
    }

    public void setupUserInfo(string phoneNumber, string displayName, bool male)
    {
        // gửi lệnh lên gs để setup những dữ liệu đầu tiên
        // nếu setup thành công
        LoginSuccess();
    }
}
