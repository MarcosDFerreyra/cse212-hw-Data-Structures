using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        if (_currX == 1)
            throw new InvalidOperationException("Can't go that way!");
        else
        {
            var position = (_currX, _currY);
            var value = _mazeMap[position];
            if (value[0] == false)
                throw new InvalidOperationException("Can't go that way!");
            else
                _currX -= 1;
        }

    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        if (_currX == 6)
            throw new InvalidOperationException("Can't go that way!");

        else
        {
            var position = (_currX, _currY);
            var value = _mazeMap[position];
            if (value[1] == false)
                throw new InvalidOperationException("Can't go that way!");
            else
                _currX += 1;
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        if (_currY == 1)
            throw new InvalidOperationException("Can't go that way!");

        else
        {
            var position = (_currX, _currY);
            var value = _mazeMap[position];
            if (value[2] == false)
                throw new InvalidOperationException("Can't go that way!");
            else
                _currY -= 1;
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        if (_currY == 6)
            throw new InvalidOperationException("Can't go that way!");

        else
        {
            var position = (_currX, _currY);
            var value = _mazeMap[position];
            if (value[3] == false)
                throw new InvalidOperationException("Can't go that way!");
            else
                _currY += 1;
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}