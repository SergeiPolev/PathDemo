using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;
        public LayerMask trapLayer;
        public LayerMask finishLayer;

        private bool dead = false;
        private bool finish = false;
        private GameSession gameSession;
        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }


            gameSession = FindObjectOfType<GameSession>();
        }

        void Update()
        {
            if (!finish)
            {
                if (!dead && (Input.touchCount > 0 || Input.GetKey(KeyCode.Space)))
                {
                    distanceTravelled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                    if (gameSession != null)
                    {
                        gameSession.tapToStartText.gameObject.SetActive(false);
                        gameSession.ChangeProgressValue(distanceTravelled);
                    }
                }
            }
            else
            {
                distanceTravelled += speed / 3 * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                if (gameSession != null)
                {
                    gameSession.ChangeProgressValue(distanceTravelled);
                }
            }
            
        }

        private void GameOver()
        {
            dead = true;
            FindObjectOfType<GameSession>().GameOver();
        }
        private void Finish()
        {
            finish = true;
            FindObjectOfType<GameSession>().Finish();
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (ExtensionMethods.Contains(trapLayer, other.gameObject.layer))
            {
                GameOver();
            }
            if (ExtensionMethods.Contains(finishLayer, other.gameObject.layer))
            {
                Finish();
            }
        }
    }
}