using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {

    }

    [SerializeField]
    private BoxCollider2D _collider;
    [SerializeField]
    private LineRenderer _template;

    public void DrawNormals ()
    {
        foreach (var segment in Segments())
        {
            var drawer = Instantiate(_template, this.transform);
            drawer.transform.position = segment.MiddlePoint;

            var startPoint = segment.MiddlePoint;
            var endPoint = segment.MiddlePoint + segment.Normal * 10;
            var positions = new Vector3[]
            {
                startPoint,
                endPoint
            };

            drawer.SetPositions(positions);
        }
    }

    IEnumerable<IPartOfPlane> Segments()
    {
        _left = transform.position.x - (_collider.size.x / 2);
        _right = transform.position.x + (_collider.size.x / 2);
        _bot = transform.position.y - (_collider.size.y / 2);
        _top = transform.position.y + (_collider.size.y / 2);

        _topLeft = new Vector2(_left, _top);
        _topRight = new Vector2(_right, _top);
        _botLeft = new Vector2(_left, _bot);
        _botRight = new Vector2(_right, _bot);

        yield return new PartOfPlane(_topLeft, _topRight, "Top");
        yield return new PartOfPlane(_topRight, _botRight, "Right");
        yield return new PartOfPlane(_botRight, _botLeft, "Bot");
        yield return new PartOfPlane(_botLeft, _topLeft, "Left");
    }

    private float _left;
    private float _right;
    private float _bot;
    private float _top;

    private Vector2 _topLeft;
    private Vector2 _topRight;
    private Vector2 _botLeft;
    private Vector2 _botRight;
}
