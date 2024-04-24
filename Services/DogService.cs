using DogClub.Entities;
using Microsoft.EntityFrameworkCore;

namespace DogClub.Services;

public class DogService
{
    private readonly EntityRepository<MatingView> _matingRepository;
    private readonly EntityRepository<PremiumMatingView> premiumRepository;
    private readonly EntityRepository<SpecialMatingView> specialMatingRepository;
    private readonly EntityRepository<Dogs> dogsRepository;
    private readonly EntityRepository<Parents> parentsRepositor;

    public DogService(EntityRepository<MatingView> matingRepository, EntityRepository<Dogs> dogsRepository,
        EntityRepository<Shows> showsRepository, EntityRepository<SpecialMatingView> specialMatingRepository,
        EntityRepository<PremiumMatingView> premiumRepository, EntityRepository<Parents> parentsRepositor)
    {
        this._matingRepository = matingRepository;
        this.dogsRepository = dogsRepository;
        this.specialMatingRepository = specialMatingRepository;
        this.premiumRepository = premiumRepository;
        this.parentsRepositor = parentsRepositor;
    }

    public async Task<List<Dogs>> GetBaseDogMating(int dogId,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<IMatingView> parentsList = await _matingRepository.GetAllAsync(cancellationToken);
        return await GetDogs(dogId, parentsList, cancellationToken);
    }

    public async Task<List<Dogs>> GetPremiumDogMating(int dogId,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<IMatingView> parentsList = await premiumRepository.GetAllAsync(cancellationToken);
        return await GetDogs(dogId, parentsList, cancellationToken);
    }

    public async Task<List<Dogs>> GetSpecialDogMating(int dogId,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<IMatingView> parentsList = await specialMatingRepository.GetAllAsync(cancellationToken);
        return await GetDogs(dogId, parentsList, cancellationToken);
    }

    private async Task<List<Dogs>> GetDogs(int dogId, IReadOnlyCollection<IMatingView> dogsVal,
        CancellationToken cancellationToken)
    {
        var allDogs = dogsVal;
        var parentList = await parentsRepositor.GetAllAsync(cancellationToken);

        var dict = new Dictionary<int, List<int>>();
        foreach (var dog in allDogs)
        {
            var queue = new Queue<int>();
            queue.Enqueue(dog.dogId);
            dict.Add(dog.dogId, new List<int>());
            while (queue.Count > 0)
            {
                var id = queue.Dequeue();
                var parents = parentList.FirstOrDefault(x => x.DogId == id);
                var parentArray = parents == null ? Array.Empty<int>() : new[] { parents.MotherId, parents.MotherId };
                if (parents != null)
                {
                    if (!dict[dog.dogId].Contains(parents.FatherId)) queue.Enqueue(parents.FatherId);
                    if (!dict[dog.dogId].Contains(parents.MotherId)) queue.Enqueue(parents.MotherId);
                }

                dict[dog.dogId].AddRange(parentArray);
            }
        }

        foreach (var item in dict)
        {
            Console.WriteLine($"{item.Key} : {string.Join(", ", item.Value)}");
        }

        // var dogParents = dict[dogId];
        if (!dict.TryGetValue(dogId, out var dogParents))
        {
            dogParents = new List<int>();
        }

        var list = new List<int>();

        foreach (var d in dict.Where(x => x.Key != dogId))
        {
            if (d.Value.All(x => !dogParents.Contains(x)))
            {
                list.Add(d.Key);
            }
        }

        var dogs = await dogsRepository.GetAllAsync(list.ToArray(), cancellationToken);
        return dogs.ToList();
    }
}