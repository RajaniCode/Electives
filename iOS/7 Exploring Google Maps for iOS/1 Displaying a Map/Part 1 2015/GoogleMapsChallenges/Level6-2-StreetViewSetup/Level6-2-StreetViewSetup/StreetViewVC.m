#import "StreetViewVC.h"

@interface StreetViewVC ()

@end

@implementation StreetViewVC

- (id)initWithNibName:(NSString *)nibNameOrNil
               bundle:(NSBundle *)nibBundleOrNil {
  self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
  if (self) {
    self.title = @"Street View";
  }
  return self;
}


- (void)viewDidLoad {
  [super viewDidLoad];
  
  self.view.backgroundColor = [UIColor whiteColor];
  
  UILabel *streetViewDataLoadingLabel = [[UILabel alloc] init];
  streetViewDataLoadingLabel.frame = CGRectMake(0, CGRectGetMidY(self.view.frame)-20, 320, 40);
  streetViewDataLoadingLabel.numberOfLines = 0;
  streetViewDataLoadingLabel.lineBreakMode = NSLineBreakByWordWrapping;
  streetViewDataLoadingLabel.textAlignment = NSTextAlignmentCenter;
  streetViewDataLoadingLabel.font = [UIFont fontWithDescriptor:[UIFontDescriptor fontDescriptorWithFontAttributes:@{NSFontAttributeName: @"Arial"}] size:16.0f];
  streetViewDataLoadingLabel.textColor = [UIColor grayColor];
  streetViewDataLoadingLabel.text = @"You'll load data in the next challenge!";
  [self.view addSubview:streetViewDataLoadingLabel];
}


- (void)viewDidAppear:(BOOL)animated {
  [super viewDidAppear:animated];
}


- (void)closeStreetView:(id)sender {
  [self.navigationController popToRootViewControllerAnimated:YES];
}

@end
