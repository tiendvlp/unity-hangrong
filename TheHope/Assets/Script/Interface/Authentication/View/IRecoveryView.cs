public interface IRecoveryView
{
	void OnRecoveryButtonClick ();
	void OnResetPasswordButtonClick ();
	void ProcessUI_ResetPasswordSuccess();
	void ProcessUI_ResetPasswordFailed ();
	void ProcessUI_RecoverySuccess ();
	void ProcessUI_RecoveryFailed ();
}
