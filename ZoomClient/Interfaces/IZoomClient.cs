using AndcultureCode.ZoomClient.Models.Users;

namespace AndcultureCode.ZoomClient.Interfaces
{
    public interface IZoomClient
    {
        User CreateUser(CreateUser createUser);
        ListUsers GetUsers();
    }
}
