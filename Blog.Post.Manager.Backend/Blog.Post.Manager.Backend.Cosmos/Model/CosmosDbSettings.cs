namespace Blog.Post.Manager.Backend.Cosmos.Model;

/// <summary>
/// The Cosmos DB settings.
/// </summary>
public class CosmosDbSettings
{
    /// <summary>
    /// The account endpoint URl.
    /// </summary>
    public string AccountEndpoint { get; set; } = default!;

    /// <summary>
    /// The database name.
    /// </summary>
    public string DatabaseName { get; set; } = default!;

    /// <summary>
    /// The container name.
    /// </summary>
    public string ContainerName { get; set; } = default!;
}
