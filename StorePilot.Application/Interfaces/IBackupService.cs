namespace StorePilot.Application.Interfaces;

public interface IBackupService
{
    string DatabasePath { get; }

    string DefaultBackupDirectory { get; }

    Task<string> CreateBackupAsync(
        string destinationPath,
        CancellationToken cancellationToken = default);
}
