#import "ProfileEditViewController.h"

@interface ProfileEditViewController ()

@end

@implementation ProfileEditViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.title = @"Edit Location";
    }
    return self;
}

- (void)viewWillAppear:(BOOL)animated {
    self.locationField.text = self.user.location;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    
    self.view.backgroundColor = [UIColor whiteColor];
    
    UILabel *locationLabel = [[UILabel alloc] init];
    locationLabel.frame = CGRectMake(20,15,50,30);
    locationLabel.text = @"location: ";
    [self.view addSubview:locationLabel];
    
    self.locationField = [[UITextField alloc] init];
    self.locationField.frame = CGRectMake(15,50,290,30);
    self.locationField.borderStyle = UITextBorderStyleBezel;
    self.locationField.keyboardType = UIKeyboardTypeDefault;
    self.locationField.delegate = self;
    [self.view addSubview:self.locationField];
    
    UIButton *saveLocationButton = [UIButton buttonWithType:UIButtonTypeRoundedRect];
    saveLocationButton.frame = CGRectMake(15,100,290,50);
    [saveLocationButton setTitle:@"Save Location" forState:UIControlStateNormal];
    [saveLocationButton addTarget:self action:@selector(saveLocation) forControlEvents:UIControlEventTouchUpInside];
    
    [self.view addSubview:saveLocationButton];
}

- (BOOL)textFieldShouldReturn:(UITextField *)textField {
    [textField resignFirstResponder];
    return YES;
}

- (void)saveLocation {
    self.user.location = self.locationField.text;
    
    [self dismissViewControllerAnimated:YES completion:nil];
}

@end