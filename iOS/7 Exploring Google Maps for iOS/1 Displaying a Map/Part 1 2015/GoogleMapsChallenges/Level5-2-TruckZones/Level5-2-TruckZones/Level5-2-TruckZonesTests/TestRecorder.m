#import "TestRecorder.h"

static NSFileHandle *__handle;

@implementation TestRecorder

+ (void)recordTestRun:(XCTestRun *)aRun;
{
    NSDictionary *info = @{
                           @"testCaseCount": @(aRun.testCaseCount),
                           @"totalFailureCount": @(aRun.totalFailureCount),
                           @"testName": aRun.test.name
                           };
    
    NSData *data = [NSJSONSerialization dataWithJSONObject:info options:0 error:nil];
    
    [__handle writeData:data];
    [__handle writeData:[@"\n" dataUsingEncoding:NSUTF8StringEncoding]];
}

+ (void) load
{
    NSString *path = [[[[NSProcessInfo processInfo] environment] objectForKey:@"DYLD_LIBRARY_PATH"] stringByAppendingPathComponent:@"test_results.log"];
    
    NSString *directoryPath = [path stringByDeletingLastPathComponent];
    
    NSError *dirError = nil;
    
    [[NSFileManager defaultManager] createDirectoryAtPath:directoryPath withIntermediateDirectories:YES attributes:nil error:&dirError];
    
    if (dirError) {
        NSLog(@"Error creating directory: %@ %@", path, dirError);
    }
    
    BOOL success = [@"" writeToFile:path atomically:YES encoding:NSUTF8StringEncoding error:nil];
    
    if (success) {
        NSLog(@"Succesfully created %@", path);
    }else{
        NSLog(@"Failed to create %@", path);
    }
    
    __handle = [NSFileHandle fileHandleForWritingAtPath:path];
}


@end