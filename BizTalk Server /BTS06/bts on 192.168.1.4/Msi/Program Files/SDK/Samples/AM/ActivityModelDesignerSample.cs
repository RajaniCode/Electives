//---------------------------------------------------------------------
// File:	ActivityModelDesignerSample.cs
// 
// Summary: 	This file contains code to create a sample Activity Model
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
using System.Collections;
using Microsoft.BizTalk.Hws.WorkflowDesign;

namespace Microsoft.Samples.BizTalk.ActivityModelSample
{
	/// <summary>
	/// This Sample demonstrates the user of the HWS Activity Model Designer API
	/// </summary>
	public class ActivityModelDesignerSample
	{
		/// <summary>
		/// HWS Constraint Clause Operators 
		/// </summary>
		enum HWSClauseOperators
		{
			EqualTo = 0,
			NotEqualTo,
			GreaterThan,
			LessThan,
			Intersection,
			Exclusion
		};

		static bool useSampleUsers = true;

		// The following role Id can be retrieved from the GetRoles method of the DesignManager class.
		static Guid initiatorRoleId = new Guid("118fe088-55b4-4654-997d-417047e9cb20");
		

		/// <summary>
		/// Application Entry Point (Mainline)
		/// </summary>
		/// <param name="args"></param>
		[STAThread]
		static void Main( string[] args )
		{
			try
			{
				Console.WriteLine( "Creating Activity Model, please wait\n" );

				// Step 1: create a new design manager
				DesignManager designManager = new DesignManager();
				Console.WriteLine(".");

				// Step 2: connect to the HWS database
				string hwsServerName = "localhost";
				string hwsDatabaseName = "BizTalkHwsDb";
				designManager.Connect( hwsServerName, hwsDatabaseName );
				Console.WriteLine(".");
			
				// Step 3: Remove the activity model if it already exists
				ActivityModelInfo[] activityModels = null;
				designManager.GetActivityModelCatalog(out activityModels);
				foreach( ActivityModelInfo existingActivityModel in activityModels )
				{
					if( existingActivityModel.Name == "Spec Review" )
					{
						designManager.RemoveActivityModelFromSystem(existingActivityModel.Id);
					}
				}
				Console.WriteLine(".");

				// Step 4: create a new Activity Model
				ActivityModel activityModel;
				designManager.CreateActivityModel( out activityModel );
				Console.WriteLine(".");

				// Step 5: set activity model properties
				activityModel.Name = "Spec Review";
				activityModel.Description = "HWS Activity Model Designer API Sample";
				Console.Write(".");

				// Step 5: add actions and transitions
				bool success = AddActionsAndTransitions( ref designManager, ref activityModel ); 
				if ( !success )
				{
					Console.WriteLine( "Failed to add actions and transitions to the activity model!" );
				}
				Console.WriteLine(".");

				// Step 6: add a simple allow all initiator constraint
				// set the constraint to "allow all"
				Constraint allowAllInitiatorConstraint = new Constraint();
				Clause allowAllClause  = new Clause();
				allowAllClause.AllowAll = true;
				allowAllInitiatorConstraint.AddClause( allowAllClause );
				activityModel.AddRoleConstraint( initiatorRoleId, allowAllInitiatorConstraint );

				// Step 7: add activity model to HWS System
				designManager.SaveActivityModelToSystem( activityModel );
				Console.WriteLine(".");
				
				// All done
				Console.WriteLine( "Successfully added new activity model to HWS System." );
			}
			catch ( Exception e )
			{
				if ( e.InnerException != null )
				{
					Console.WriteLine( e.InnerException.Message );
				}
				else
				{
					Console.WriteLine( e.Message );
				}

				Console.WriteLine("Exception stack:");
				Console.Write(e.StackTrace + "\n\n");
			}

			Console.WriteLine( "Press <Enter> key to exit." );
			Console.Read();
		}


		/// <summary>
		/// AddActionsAndTransitions method
		/// </summary>
		/// <param name="designManager"></param>
		/// <param name="activityModel"></param>
		/// <returns>true on success</returns>
		static bool AddActionsAndTransitions( ref DesignManager designManager, ref ActivityModel activityModel )
		{
			// grab the actions registered in HWS
			ActionInfo[] actionsList;
			designManager.GetActionCatalog( out actionsList );
			if ( ( actionsList == null ) || ( actionsList.Length == 0 ) )
			{
				Console.WriteLine( "No registered actions found in HWS" );
				return false;
			}
	    
			// find the Assign action in the action list
			Guid assignActionID = Guid.Empty;
			string actionName = "Microsoft.Samples.BizTalk.Actions.Assign";
			for( int j = 0; j < actionsList.Length; j++ )
			{
				if ( String.Compare( actionsList[j].Name, actionName, true ) == 0 )		
				{
					// extract action ID
					assignActionID = actionsList[j].Id;
					break;
				}
			}
			if ( assignActionID == Guid.Empty )
			{
				Console.WriteLine( "Can't find Assign action in actions registered with HWS!" );
				return false;
			}
		    
			// add the Assign Action as the three steps in our activity model
			Step step1, step2, step3;
			activityModel.AddStep( assignActionID, out step1 );
			activityModel.AddStep( assignActionID, out step2 );
			activityModel.AddStep( assignActionID, out step3 );
					
			// Set the step names
			step1.Name = "Review Specification";
			step2.Name = "Update Specification";
			step3.Name = "Final Approval";
			
			// Get all the constraint facts stored in HWS from the design manager
			ConstraintFact[] constraintFacts;
			designManager.GetConstraintFacts( out constraintFacts );
			
			// Find the fact retriver id and property id of the username property
			// supplied by the intrinsic fact retriever
			int constraintFactType = 0;
			Guid propertyID = Guid.Empty;
			Guid factRetrieverID = Guid.Empty;
			string constraintFactName = "IntrinsicUserName";
			for ( int i = 0; i < constraintFacts.Length; i++ )
			{
				if ( String.Compare( constraintFacts[i].Name, constraintFactName, true ) == 0 )
				{
					constraintFactType = constraintFacts[i].Type;
					propertyID =  constraintFacts[i].Id;
					factRetrieverID = constraintFacts[i].FactRetrieverId;
				}
			}
			if ( propertyID == Guid.Empty )
			{
				Console.WriteLine( "Can't find IntrinsicUserName in constraint facts registered with HWS!" );
				return false;
			}
			
			// Set all the required clause properties
			Clause targetClause  = new Clause();
			targetClause.FactRetrieverId = factRetrieverID;
			targetClause.PropertyId = propertyID;
			targetClause.Operator = (int) HWSClauseOperators.EqualTo;
			targetClause.XPath = null;
			
			// Set the clause value so that only Mary can be chosen as the target
			ArrayList clauseValues = new ArrayList();
			ClauseValue clauseValue = new ClauseValue();
			clauseValue.Value = Environment.MachineName + "\\Mary";

			clauseValue.RelatedFactRetrieverId = Guid.Empty;
			clauseValue.RelatedPropertyId = Guid.Empty;
			clauseValue.RelatedToEnacted = false;
			clauseValue.RelatedToSource= false;
			clauseValues.Add( clauseValue );
			targetClause.Values = clauseValues;

			// Add the target constraint to the third step
			Constraint targetConstraint = new Constraint();
			targetConstraint.AddClause( targetClause );
			step3.AddTargetConstraint( targetConstraint );
			
			// add the transitions between the steps of our Activity Model
			Transition transition12;
			Transition transition21;
			Transition transition13;
			Transition transition31;
			bool isDependentComposition = false;
			activityModel.AddTransition( step1.Id, step2.Id, isDependentComposition, "", "", out transition12 );
			activityModel.AddTransition( step2.Id, step1.Id, isDependentComposition, "", "", out transition21 );
			activityModel.AddTransition( step1.Id, step3.Id, isDependentComposition, "", "", out transition13 );
			activityModel.AddTransition( step3.Id, step1.Id, isDependentComposition, "", "", out transition31 );
			
			// return success
			return true;
		}
	}
}
