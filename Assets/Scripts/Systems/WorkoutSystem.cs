using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkoutSystem : Systems
{
    public static WorkoutSystem instance;
    public List<Workout> allWorkouts;
    public override void Init()
    {
        if (instance != this && instance != null) Destroy(gameObject);

        instance = this;

        allWorkouts = new List<Workout>
        {
            new Workout("Push-Ups", "Incline Push-Ups, Decline Push-Ups, Diamond Push-Ups", 10, 70, TaskType.tasktype.STRENGTH),
            new Workout("Pull-Ups", "Chin-Ups, Wide Grip Pull-Ups, Archer Pull-Ups", 12, 60, TaskType.tasktype.STRENGTH),
            new Workout("Squats", "Narrow Squats, Sumo Squats, Jump Squats", 8, 75, TaskType.tasktype.STRENGTH),
            new Workout("Lunges", "Reverse Lunges, Side Lunges, Walking Lunges", 10, 65, TaskType.tasktype.STRENGTH),
            new Workout("Plank", "Side Plank, Plank with Arm Reach, Plank to Push-Up", 8, 70, TaskType.tasktype.STRENGTH),
            new Workout("Burpees", "Burpee with Push-Up, Half Burpee, Jump Tuck Burpee", 14, 50, TaskType.tasktype.STRENGTH),
            new Workout("Mountain Climbers", "Crossbody Climbers, Slow Climbers, Spider Climbers", 14, 55, TaskType.tasktype.STAMINA),
            new Workout("Jumping Jacks", "Seal Jacks, Step Jacks, Squat Jacks", 6, 70, TaskType.tasktype.STAMINA),
            new Workout("Dips (Chair or Parallel Bar)", "Bench Dips, Straight Bar Dips, Korean Dips", 13, 60, TaskType.tasktype.STRENGTH),
            new Workout("Crunches", "Reverse Crunches, Bicycle Crunches, Crossbody Crunches", 10, 65, TaskType.tasktype.STRENGTH),
            new Workout("Sit-Ups", "V-Ups, Weighted Sit-Ups, Butterfly Sit-Ups", 12, 60, TaskType.tasktype.STRENGTH),
            new Workout("Wall Sits", "Wall Sit with Arm Raises, Single-Leg Wall Sit, Weighted Wall Sit", 12, 65, TaskType.tasktype.STRENGTH),
            new Workout("Glute Bridges", "Single-Leg Bridge, Elevated Glute Bridge, Frog Pumps", 10, 70, TaskType.tasktype.STRENGTH),
            new Workout("Calf Raises", "Single-Leg Calf Raises, Seated Calf Raises, Pulse Raises", 8, 75, TaskType.tasktype.STRENGTH),
            new Workout("Jump Squats", "180 Jump Squats, Tuck Jump Squats, Lateral Jump Squats", 14, 45, TaskType.tasktype.STRENGTH),
            new Workout("Pike Push-Ups", "Elevated Pike Push-Ups, Wide Pike Push-Ups, Slow Negatives", 15, 50, TaskType.tasktype.STRENGTH),
            new Workout("Handstand Hold", "Wall Support Hold, Freestanding Hold, Shoulder Tap Hold", 16, 40, TaskType.tasktype.STRENGTH),
            new Workout("High Knees", "High Knees in Place, Lateral High Knees, Skater High Knees", 12, 55, TaskType.tasktype.STAMINA),
            new Workout("Shadow Boxing", "Fast Punch Combos, Defensive Movements, Shadow Kicks", 10, 60, TaskType.tasktype.STAMINA),
            new Workout("Bear Crawls", "Forward/Backward Crawl, Lateral Crawl, Elevated Bear Crawl", 10, 50, TaskType.tasktype.STAMINA),
        
            // Added extras
            new Workout("Jump Rope", "Basic Jump, Double Unders, Criss-Cross", 8, 65, TaskType.tasktype.STAMINA),
            new Workout("Box Jumps", "Lateral Box Jumps, Step-Downs, Single-Leg Jumps", 14, 50, TaskType.tasktype.STRENGTH),
            new Workout("Leg Raises", "Hanging Leg Raises, Lying Leg Raises, Flutter Kicks", 12, 60, TaskType.tasktype.STRENGTH),
            new Workout("Superman Hold", "Superman Raise, Alternating Superman, Weighted Superman", 10, 60, TaskType.tasktype.STRENGTH),
            new Workout("Hip Thrusts", "Banded Hip Thrusts, Weighted Thrusts, Pause Reps", 13, 70, TaskType.tasktype.STRENGTH),
            new Workout("Skaters", "Jump Skaters, Low Skaters, Banded Skaters", 12, 60, TaskType.tasktype.STAMINA),
        
        
             // cardio / running based
            new Workout("Sprinting", "Interval Sprints, Hill Sprints, Resistance Sprints", 10, 60, TaskType.tasktype.STAMINA),
            new Workout("Jogging", "Treadmill Jog, Light Outdoor Jog, Jog in Place", 12, 55, TaskType.tasktype.STAMINA),
            new Workout("Running", "Long-Distance Run, Tempo Run, Fartlek Run", 15, 70, TaskType.tasktype.STAMINA),
            new Workout("Power Walking", "Incline Walk, Arm-Swing Walk, Fast Paced Walk", 10, 50, TaskType.tasktype.STAMINA),

            // kids-friendly / easy beginner
            new Workout("Animal Walks", "Bear Walk, Crab Walk, Frog Jumps", 6, 40, TaskType.tasktype.STAMINA),
            new Workout("Basic Stretching", "Neck Rolls, Arm Circles, Toe Touch", 5, 30, TaskType.tasktype.STRENGTH),
            new Workout("Fun Dance Moves", "Jump Twist, Step Touch, Freestyle Bounce", 8, 45, TaskType.tasktype.STAMINA),

            // elderly-friendly / very light
            new Workout("Chair Exercises", "Seated Leg Lifts, Arm Raises, Seated March", 6, 35, TaskType.tasktype.STRENGTH),
            new Workout("Balance Drills", "One-Leg Stand, Heel-to-Toe Walk, Gentle Shifts", 6, 30, TaskType.tasktype.STRENGTH),
            new Workout("Light Yoga", "Cat-Cow, Child's Pose, Seated Twist", 10, 40, TaskType.tasktype.STRENGTH),
            new Workout("Slow Marching", "March in Place, Side Steps, Heel Lifts", 8, 35, TaskType.tasktype.STAMINA),

            // for the kids

            new Workout("Hopscotch", "Basic Hopscotch, Double Foot Hop, Speed Hop", 6, 40, TaskType.tasktype.STAMINA),
            new Workout("Jump Rope Kids", "Single Bounce, Boxer Skip, Backward Jump", 8, 50, TaskType.tasktype.STAMINA),
            new Workout("Mini Circuit", "10s Jumping Jacks, 10s Squats, 10s Rest", 6, 55, TaskType.tasktype.STRENGTH),
            new Workout("Crawling Games", "Bear Crawl, Crab Walk, Inch Worm", 5, 35, TaskType.tasktype.STAMINA),
            new Workout("Playground Strength", "Monkey Bars, Hanging Hold, Light Push-Ups", 7, 60, TaskType.tasktype.STRENGTH),
            new Workout("Dance Fitness", "Step Touch, Side Sways, Arm Swings", 10, 50, TaskType.tasktype.STAMINA),
            new Workout("Balance Games", "One Foot Stand, Flamingo Pose, Line Walk", 6, 30, TaskType.tasktype.STRENGTH),
            new Workout("Agility Drills", "Cone Zig-Zag, Ladder Step, Quick Feet", 10, 65, TaskType.tasktype.STAMINA),
            new Workout("Wall Touch Drill", "Tap high/low points on wall quickly", 8, 60, TaskType.tasktype.STAMINA),
            new Workout("Animal Movements", "Duck Walk, Bunny Hops, Elephant Stomps", 7, 45, TaskType.tasktype.STAMINA),

            new Workout("HIIT Circuit", "Burpees, Mountain Climbers, Jump Squats", 20, 35, TaskType.tasktype.STAMINA),
            new Workout("Core Shred", "Leg Raises, Plank Holds, Flutter Kicks", 20, 35, TaskType.tasktype.STRENGTH),
            new Workout("Explosive Power", "Box Jumps, Plyo Push-Ups, Broad Jumps", 20, 35, TaskType.tasktype.STRENGTH),
            new Workout("Mobility Flow", "Hip Opener, Shoulder Rolls, Ankle Circles", 20, 35, TaskType.tasktype.STRENGTH),
            new Workout("Cardio Burnout", "Jump Rope, High Knees, Skaters", 20, 35, TaskType.tasktype.STAMINA),
            new Workout("Isometric Core", "Plank, Wall Sit, Hollow Hold", 20, 35, TaskType.tasktype.STRENGTH),
            new Workout("Calisthenics Flow", "Push-Ups, Pull-Ups, Dips", 20, 35, TaskType.tasktype.STRENGTH),
            new Workout("Athlete Conditioning", "Sprint Bursts, Jump Lunges, Shadow Boxing", 20, 35, TaskType.tasktype.STAMINA),

            new Workout("Chair Yoga", "Seated Cat-Cow, Neck Stretch, Arm Circles", 65, 95, TaskType.tasktype.STRENGTH),
            new Workout("Gentle Stretch", "Hamstring Stretch, Shoulder Rolls, Wrist Flex", 65, 95, TaskType.tasktype.STRENGTH),
            new Workout("Balance Boost", "Toe Taps, Heel Lifts, Standing March", 65, 95, TaskType.tasktype.STRENGTH),
            new Workout("Walking Drills", "5-Min Walk, Step Ups (Low), Side Steps", 65, 95, TaskType.tasktype.STAMINA),
            new Workout("Low Impact Cardio", "Seated Jacks, Arm Raises, Air Punches", 65, 95, TaskType.tasktype.STAMINA),
            new Workout("Breathing & Relaxation", "Deep Breathing, Gentle Neck Turns, Shoulder Shrugs", 65, 95, TaskType.tasktype.STRENGTH),
            new Workout("Everyday Strength", "Wall Push-Ups, Sit to Stand, Can Lifts", 65, 95, TaskType.tasktype.STRENGTH),
            new Workout("Posture Fix", "Wall Slides, Chin Tucks, Shoulder Squeeze", 65, 95, TaskType.tasktype.STRENGTH),

        };
    }

    // strength ones for building muscles
    // stamina ones for cutting
    // strenght + stamina for body recomp

    // change this to get randoms
    public List<Task> getWorkouts(int amount, int age, TaskType.tasktype type)
    {
        Debug.Log(age);

        // 1. Filter valid workouts
        List<Workout> validWorkouts = allWorkouts.Where(w =>
            w.taskType == type && age >= w.minAge && age <= w.maxAge
        ).ToList();

        if (validWorkouts.Count == 0)
        {
            Debug.LogWarning("No valid workouts found for this age/type.");
            return new List<Task>();
        }

        // 2. Shuffle the valid workouts
        for (int i = validWorkouts.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            var temp = validWorkouts[i];
            validWorkouts[i] = validWorkouts[j];
            validWorkouts[j] = temp;
        }

        // 3. Select as many as possible up to 'amount'
        int count = Mathf.Min(amount, validWorkouts.Count);
        List<Task> selectedTasks = new List<Task>();

        for (int i = 0; i < count; i++)
        {
            Workout w = validWorkouts[i];
            Task task = new Task(
                type,
                TaskSystem.instance.getNewTaskID(),
                w.workoutName,
                w.workoutVariation,
                60,
                60,
                SLSParameters.instance.getRewardOnTaskComplete()
            );
            TaskSystem.instance.pushTask(task);
            selectedTasks.Add(task);
        }

        return selectedTasks;
    }

    //public List<Task> getWorkouts(int amount, int age, TaskType.tasktype type)
    //{
    //    Debug.Log(age);
    //    for(int i = 0; i < amount;)
    //    {
    //        int randomInt = Random.Range(0, allWorkouts.Count);

    //        Workout w = allWorkouts[randomInt];

    //        if (w.taskType == type && age >= w.minAge && age <= w.maxAge)
    //        {
    //            TaskSystem.instance.pushTask(new Task(
    //                type,
    //                TaskSystem.instance.getNewTaskID(),
    //                w.workoutName, // assuming u wanna show the name
    //                w.workoutVariation,
    //                60,
    //                60,
    //                SLSParameters.instance.getRewardOnTaskComplete()
    //            ));

    //            i++;
    //            //amount--;

    //            //if (amount <= 0) break;
    //        }
    //    }
    //foreach (Workout w in allWorkouts)
    //{
    //    if (w.taskType == type && age >= w.minAge && age <= w.maxAge)
    //    {
    //        TaskSystem.instance.pushTask(new Task(
    //            type,
    //            TaskSystem.instance.getNewTaskID(),
    //            w.workoutName, // assuming u wanna show the name
    //            w.workoutVariation,
    //            0,
    //            0,
    //            SLSParameters.instance.getRewardOnTaskComplete()
    //        ));

    //        amount--;

    //        if (amount <= 0) break;
    //    }
    //}

    //return null;
}
