Feature: Whinge
	As a whinger, I would like to whinge to a whinge pool

Background: 
	Given An Azure Storage Configuration of
		| StorageAccount | StorageAccountKey                                                                        |
		| myobpdqaart    | MHDYieseAgGX6HbE8yWK4e0L2eKkUt+an6UbX1/6o0nC2FK2pmgxi/OVW+WEVyH50ROBRMtw0wxf057KDTaDfA== |

	And A Pegasus Configuration of
		| ScheduledTasksQueueName              | RegisteredHandlersTableName | RegisteredHandlersBlobContainerName | RuntimeErrorsTableName  |
		| whingepool-test-scheduled-task-queue | WhingePoolHandlers          | whingepool-handler-assemblies       | WhingePoolRuntimeErrors |

	And A WhingePool Configuration of
		| WhingesTableName | WhingersTableName | WhingePoolsTableName | WhingesByWhingerTableName | WhingesByWhingePoolTableName |
		| Whinges          | Whingers          | WhingePools          | WhingesByWhinger          | WhingesByWhingePool          |

	And An ApplicationContext

	And An Empty WhingersTable

	And A Default Set Of Whingers
		| TwitterHandle |
		| johnazariah   |

	And An Empty WhingePoolsTable

	And A Default Set Of WhingePools
		| Name  |
		| Test  |
		| Work  |
		| Azure |

	And The Current Whinger
		| TwitterHandle |
		| johnazariah   |
		 
Scenario: Save a invalid Whinge of more than 150 characters to an existing WhingePool 
	When A whinge is saved
		| Whinge                                                                                                                                                                                               | WhingePool |
		| I would really like to learn to whinge properly. I really don't know how to keep it short enough for Whinger to accept. Why cannot I learn to whinge within a limit of hundred and fifty characters? | Test       |
	Then An instance of "WhingeTooLong" exception should be thrown 

Scenario: Save a valid Whinge to an existing WhingePool 
	When A whinge is saved
		| Whinge                          | WhingePool |
		| This is a really common whinge! | Test       |
	Then The save should succeed

Scenario: Save a valid Whinge to an non-existing WhingePool 
	When A whinge is saved
		| Whinge                                     | WhingePool |
		| I hate having to go to the gym in the cold | Exercise   |
	Then A WhingePool should be created
		| Name     |
		| Exercise |
	And The save should succeed
