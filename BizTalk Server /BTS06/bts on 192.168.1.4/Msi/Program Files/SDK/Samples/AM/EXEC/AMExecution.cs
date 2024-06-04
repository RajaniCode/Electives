//---------------------------------------------------------------------
// File:	AMExecution.cs
// 
// Summary: 	This file contains code to execute a sample Activity Model
//
// Sample: 	HWS Activity Model Sample
//
//---------------------------------------------------------------------
// This file is part of the Microsoft BizTalk Server 2006 SDK
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft BizTalk
// Server 2006 release and/or on-line documentation. See these other
// materials for detailed information regarding Microsoft code samples.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
// PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Net;
using System.Xml;
using System.Threading;


namespace Microsoft.Samples.BizTalk.ActivityModelSample
{
  /// <summary>
  /// AMDAPIClient
  /// </summary>
	class AMDAPIClient
	{
	  /// <summary>
	  /// Main line
	  /// </summary>
	  /// <param name="args"></param>
		[STAThread]
		static void Main( string[] args )
		{
      try
      {
        Console.Write( "Starting activity model, please wait" );
        
        // Create the HWS Web service object
        HWS.HwsService hwss = new HWS.HwsService();

        // We will execute the activity model in the following order:
        // "Review Specification" -> "Update Specification" -> "Review Specification" -> Final Approval".
        // Hence, we need to create 4 tasks
        // the user array will give us the initiator (index i) and the task target (index i + 1)
        string[] myStepOrder = { "Review Specification", "Update Specification", "Review Specification", "Final Approval" };
        string[] myUserOrder = { "John", "Susan", "John", "Susan", "Mary" };
        
        // To create a new Activity flow, we need to get a new 
        // Activity flow ID.  We do this by calling GetNewActivityFlowID.
        // Programmatically, we must call the web-service with the credentials we provide
        // We do this by creating a new credentials object
         hwss.Credentials = new NetworkCredential(myUserOrder[0], "pass@word1");

				Guid activityFlowID = hwss.GetNewActivityFlowID();
        Console.Write( ".");

        // We need to keep track of the parent action instance ID, the parent task ID
        // and the activity model instance ID
        Guid parentActionInstanceID = Guid.Empty;
        Guid parentTaskID = Guid.Empty;
        Guid activityModelInstanceID = Guid.Empty;
        for ( int i = 0; i < 4; i++ )
        {
          // set our HWS credentials for the current itteration
          string taskTarget = "";
          hwss.Credentials = new NetworkCredential( myUserOrder[i], "pass@word1");
          taskTarget = Environment.MachineName + "\\" + myUserOrder[i + 1];
                    
          // Now Query the HWS Web Service for all the available actions and activity models that we
          // (the Initiator) can run.
          // We won't act on behalf of anyone else, i.e. we want to use our own redentials to call
          // the web-service, hence we set the "actingUser" parameter to null throughout the sample
          HWS.Activity[] activities = hwss.GetActivityList( activityFlowID, parentActionInstanceID, parentTaskID, null, null );
          Console.Write( ".");
          
          // Now we iterate through the activity list to find the type ID of the activity model
          // called "Review Spec", along with the correct step name for this iteration
          Guid activityModelTypeID = Guid.Empty;
          Guid activationBlockID = Guid.Empty;
          foreach ( HWS.Activity activity in activities )
          {
            if ( activity.Name == "Spec Review" ) 
            {
              // first check if the activity flow is already executing
              if ( i > 0 )
              {
                if ( activity.StepName == myStepOrder[i] )
                {
                  activityModelTypeID = activity.ActivityModelTypeID;
                  activationBlockID = activity.ActivationBlockID;
                }
              }
              else
              {
                activityModelTypeID = activity.ActivityModelTypeID;
                activationBlockID = activity.ActivationBlockID;
              }
            }
          }

          if ( activityModelTypeID == Guid.Empty )
          {
            throw new Exception( "Required Step in Activity Model 'Spec Review' not found." );
          }
          Console.Write( ".");
          
          // Now we need to find out what the activity parameters are
          HWS.ActionParameters[] parametersList = hwss.GetActivityModelParameters( activityModelTypeID, activationBlockID, null );
          if ( parametersList == null )
          {
            throw new Exception( "Couldn't retrieve parameter list." );
          }
          Console.Write( ".");
          
          // Now fill the parameters from the Assign action's activation message
          // The Assign action is the one used in all the steps within the "Spec Review" activity model
          XmlDocument assignActionActivationMessage = new XmlDocument();
          assignActionActivationMessage.Load( @"..\..\AssignActionActivationMessage.xml" );	
          foreach ( HWS.ActionParameters parameters in parametersList )
          {
            fillInActionActivationMessage( taskTarget,
                                           parameters,
                                           ref assignActionActivationMessage );
            parameters.ParametersDoc = assignActionActivationMessage.OuterXml;
            Console.Write( ".");
          }

          // Now create and execute the activity model. This returns the activity model instance ID
          activityModelInstanceID = hwss.AddActivationBlockToActivityFlow( activityFlowID,
                                                                           activityModelInstanceID,
                                                                           parentActionInstanceID,
                                                                           parentTaskID,
                                                                           false,
                                                                           parametersList,
                                                                           null );
          Console.Write( ".");
          
          // Now we can retrieve the tracking information for our activity flow instance from the tracking
          // database by calling GetActivityFlowInfo().
          // We're especially interested in retrieving the actionInstanceID and taskID.
          Guid actionInstanceID = Guid.Empty;
          Guid taskID = Guid.Empty;
          int numRetries = 5;
          while ( ( taskID == Guid.Empty ) && ( numRetries > 0 ) )
          {
            Thread.Sleep( 2000 );
            HWS.ActivityFlow activityFlowInfo = hwss.GetActivityFlowInfo( activityFlowID, HWS.ActivityFlowDetailLevel.TaskLevel, null );
            numRetries--;
            if ( activityFlowInfo != null )
            {
               Console.WriteLine( "\n\n"
                                + "Current Activity Flow Description: {0}\n"
                                + "Current Activity Flow Status: {1}\n"
                                + "Current Action Instance count: {2}",
                                activityFlowInfo.ActivityFlowDescription,
                                activityFlowInfo.Status,
                                activityFlowInfo.StatInfo.ActionInstanceCount );
              getCurrentActionInstanceIDAndTaskID( activityFlowInfo.RootActionInstances,
                                                   ref actionInstanceID,
                                                   ref taskID );
            }
          }
          
          if ( taskID == Guid.Empty )
          {
            throw new Exception( "Unable to retrieve taskID." );
          }
          
          // Now the user targetted by the action just added should complete the current task.

					// Wait 6 seconds to accomodate tracking latency
          Thread.Sleep( 6000 );

          // Get the task message
          string taskMessage = hwss.GetTaskMessage( taskID, null ); 
          XmlDocument message = new XmlDocument();
          message.LoadXml( taskMessage );
          
          // Set the task status to completed
          message.SelectSingleNode( "//HwsSection/TaskStatus").InnerText = "Completed";

					// Change the credentials to the user targetted by the action
					hwss.Credentials = new NetworkCredential(myUserOrder[i+1], "pass@word1");

          // Send the task response message
          hwss.SendTaskResponse( message.OuterXml, null );
          Console.Write( ".");
          
          // Update the parent step information
          parentActionInstanceID = actionInstanceID;
          parentTaskID = taskID;
          Console.WriteLine();
        }

        // All done, access the tracking database one last time
        Guid dummyActionInstanceID = Guid.Empty;
        Guid dummyTaskID = Guid.Empty;
        int dummyNumRetries = 5;
        while ( ( dummyTaskID == Guid.Empty ) && ( dummyNumRetries > 0 ) )
        {
          Thread.Sleep( 2000 );
          HWS.ActivityFlow activityFlowInfo = hwss.GetActivityFlowInfo( activityFlowID, HWS.ActivityFlowDetailLevel.TaskLevel, null );
          Console.Write( ".");
          dummyNumRetries--;
          if ( activityFlowInfo != null )
          {
            Console.WriteLine( "\n\n"
                             + "Current Activity Flow Description: {0}\n"
                             + "Current Activity Flow Status: {1}\n"
                             + "Current Action Instance count: {2}",
                             activityFlowInfo.ActivityFlowDescription,
                             activityFlowInfo.Status,
                             activityFlowInfo.StatInfo.ActionInstanceCount );
            getCurrentActionInstanceIDAndTaskID( activityFlowInfo.RootActionInstances,
                                                 ref dummyActionInstanceID,
                                                 ref dummyTaskID );
          }
        }
  
        Console.WriteLine( "Activity Flow Complete. Press ENTER key to close." );
        Console.Read();

      }
      catch ( Exception e )
      {
        if ( e.InnerException != null )
        {
          Console.WriteLine( "\n\n" + e.InnerException.Message );      
        }
        else
        {
          Console.WriteLine( "\n\n" + e.Message );
        }
        Console.WriteLine( "Critial Stop. Press ENTER key to close." );
        Console.Read();
      }
  	}
  	
  	/// <summary>
  	/// fillInActionActivationMessage
  	/// </summary>
  	/// <param name="targetUserID"></param>
  	/// <param name="parameters"></param>
  	/// <param name="actionActivationMessage"></param>
  	static void fillInActionActivationMessage( string targetUserID,
  	                                           HWS.ActionParameters parameters,
  	                                           ref XmlDocument actionActivationMessage )
  	{
      NameTable nameTable = new NameTable();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager( nameTable );
      nsmgr.AddNamespace( "hws", "http://schemas.microsoft.com/Hws/2003" );
      nsmgr.AddNamespace( "xs", "http://www.w3c.org/2001/XMLSchema" );
      nsmgr.AddNamespace( "ns0", "http://tempuri.org/Hws_AssignTask_Activate" );
      
      // fill in the activity flow description
      XmlNode hwsSection = actionActivationMessage.SelectSingleNode( "//ns0:HwsMessage/HwsSection", nsmgr );
      hwsSection.SelectSingleNode( "./ActivityFlowDescription" ).InnerText = parameters.Action.Name;
 
      // fill in the Task section of the activation message
      XmlNode taskNode = actionActivationMessage.SelectSingleNode( "//ns0:HwsMessage/ActionSection/Task", nsmgr );
      
      // generate the start date
      DateTime startDate = DateTime.Now;
      string startDateString = startDate.ToString( "s" );
        
      // set the deadline
      DateTime deadline = new DateTime( 2005, 1 , 1 );
      string deadlineString = deadline.ToString( "s" );
	
      // set ourselves to be the task target (we're assigning ourselves to the task)
      taskNode.SelectSingleNode( "./Target" ).InnerText = targetUserID;
      taskNode.SelectSingleNode( "./Status" ).InnerText = "1"; // "1" means "Not Started"
      taskNode.SelectSingleNode( "./Description" ).InnerText = parameters.Action.StepName;
      taskNode.SelectSingleNode( "./StartDate" ).InnerText = startDateString;
      taskNode.SelectSingleNode( "./Deadline" ).InnerText = deadlineString;
	  }
	  
	  
	  /// <summary>
	  /// getCurrentActionInstanceIDAndTaskID
	  /// </summary>
	  /// <param name="actionInstances"></param>
	  /// <param name="actionInstanceID"></param>
	  /// <param name="taskID"></param>
    static void getCurrentActionInstanceIDAndTaskID( HWS.ActionInstance[] actionInstances, ref Guid actionInstanceID, ref Guid taskID )
    {
      // This code assumes that there is only one action instance, i.e. actionInstances[0], at this step
      if ( ( actionInstances != null ) && ( actionInstances[0] != null ) )
      {
        HWS.Task[] tasks = actionInstances[0].Tasks;
        // this code assumes that there is only one task, i.e. task[0], spawed by the action instance
        if ( ( tasks != null ) && ( tasks[0] != null ) )
        {
          Console.WriteLine( "\n"
                           + "Action Name: {0}\n"
                           + "Action Status: {1}\n"
                           + "Activity Model Name: {2}\n"
                           + "Task Description: {3}\n"
                           + "Current Task Status: {4}\n"
                           + "Task Initiator: {5}\n"
                           + "Task Target: {6}\n",
                           actionInstances[0].Name,
                           actionInstances[0].Status,
                           actionInstances[0].ActivityModelName,
                           actionInstances[0].Tasks[0].TaskDescription,
                           actionInstances[0].Tasks[0].CurrentStatus,
                           actionInstances[0].Tasks[0].Initiator,
                           actionInstances[0].Tasks[0].Target );
          actionInstanceID = actionInstances[0].ActionInstanceID;
          taskID = tasks[0].TaskID;
        }
        
        // recurse
        getCurrentActionInstanceIDAndTaskID( actionInstances[0].ChildActionInstances, ref actionInstanceID, ref taskID );
      }
    }
	}
}
