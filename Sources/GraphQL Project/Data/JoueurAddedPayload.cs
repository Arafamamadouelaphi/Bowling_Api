using DTOs;

namespace GraphQL_Project.Data;

public class JoueurAddedPayload
{
    public JoueurDTO Joueur { get; }

    public JoueurAddedPayload(JoueurDTO joueur)
    {
        Joueur = joueur ?? throw new ArgumentNullException(nameof(joueur));
    }
}