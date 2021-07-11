using System;

namespace Junoon.Core
{
    //Todo add 2 generic parameters. One as the loop type [int, float, double] and second as Delegate Type
    public class ForLoop
    {
    #region Properties

    public string NodeType { get; }
    public string Operation { get; }

    public Iterator Iterator { get; }
    public LoopCondition Condition { get; }

    //Todo Make this generic numeric. Provide your own types if you have to. 
    public int ComparisonValue { get; }

    //Todo Make this generic numeric. Provide your own types if you have to. 
    public int InitialValue { get;  }

    //Todo Make this generic numeric. Provide your own types if you have to. 
    public int CurrentIndex { get; private set; }
    public Action Action { get; }
    #endregion

    #region Private Variables
    #endregion

    #region Constructors

    //Todo Make the constructor Generic or rather the entire Numeric Generic 
    public ForLoop(Iterator iterator, int initialValue, LoopCondition condition, int comparisonValue, Action action)
    {
        Operation = "ForLoop";
        NodeType = "Loop";
        this.Iterator = iterator;
        this.Condition = condition;
        this.ComparisonValue = comparisonValue;
        this.Action = action;
        this.InitialValue = initialValue;
        CurrentIndex = initialValue;
    }

    #endregion

    #region Internal Types

    public enum LoopCondition
    {
        GreaterThan,
        LessThan,
        EqualsTo,
        NotEqualsTo,
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Iterates once
    /// </summary>
    /// <returns>the current Iterator value</returns>
    public int IterateOnce()
    {
        var status = LoopConditionCompare(CurrentIndex, ComparisonValue, Condition);
        if (status)
        {
            CurrentIndex = Execute(this.CurrentIndex, this.Iterator, this.Action);
            return CurrentIndex;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void IterateAll()
    {
        bool status = LoopConditionCompare(CurrentIndex, ComparisonValue, Condition);;
        while (status is false)
        {
            try
            {
                CurrentIndex = Execute(CurrentIndex, Iterator, Action);
            }
            catch (Exception e)
            {
                throw;
            }
            status = LoopConditionCompare(CurrentIndex, ComparisonValue, Condition);
        }
    }

    #endregion


    #region Static Methods

    /// <summary>
    /// Mutates the provided value and invokes provided action
    /// </summary>
    /// <param name="value">The iterator value to mutate</param>
    /// <param name="iterator">an Iterator object holding iterator information</param>
    /// <param name="action">The action to invoke</param>
    /// <returns>mutated value</returns>
    private static int Execute(int value, Iterator iterator, Action action)
    {
        action.Invoke();

        if (iterator.Sign == Iterator.IteratorSign.Positive)
            value+=Convert.ToInt32(iterator.StepSize);

        else if (iterator.Sign == Iterator.IteratorSign.Negative)
        {
            value-=Convert.ToInt32(iterator.StepSize);
        }

        return value;
    }


    private static bool LoopConditionCompare(int indexer, int comparer, LoopCondition condition)
    {
        switch (condition)
        {
            case LoopCondition.GreaterThan:
                return indexer > comparer;

            case LoopCondition.LessThan:
                return indexer < comparer;

            case LoopCondition.EqualsTo:
                return indexer == comparer;

            case LoopCondition.NotEqualsTo:
                return indexer != comparer;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion

    }
}