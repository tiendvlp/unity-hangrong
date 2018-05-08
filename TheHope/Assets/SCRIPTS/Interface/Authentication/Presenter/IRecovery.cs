public interface IRecovery{
	void StartRecovery(string userName);

	void ResetPassword(string token, string newPassword);

}
