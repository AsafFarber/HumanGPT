using UnityEngine;
using Zenject;
using Cinemachine;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private HealthPointsManager healthPoints;

    [SerializeField]
    private CollectionManager collectionManager;

    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    public override void InstallBindings()
    {
        Container.Bind<IterationManager>().AsSingle();
        Container.Bind<Camera>().FromComponentInHierarchy(cam).AsSingle();
        Container.Bind<HealthPointsManager>().FromComponentInHierarchy(healthPoints).AsSingle();
        Container.Bind<CollectionManager>().FromComponentInHierarchy(collectionManager).AsSingle();
        Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy(virtualCamera).AsSingle();
    }
}
