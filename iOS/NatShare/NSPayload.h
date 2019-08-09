//
//  NSSharePayload.h
//  NatShare
//
//  Created by Yusuf Olokoba on 8/8/19.
//  Copyright © 2019 Yusuf Olokoba. All rights reserved.
//

@import Foundation;
@import UIKit;

typedef void (^CompletionHandler) (void);

@protocol NSPayload <NSObject>
@optional
- (void) addText:(nonnull NSString*) text;
@required
- (void) addImage:(nonnull UIImage*) image;
- (void) addMedia:(nonnull NSURL*) url;
- (void) commit;
- (void) dispose;
@end

@interface NSSharePayload : NSObject <NSPayload>
- (instancetype) initWithCompletionHandler:(nullable CompletionHandler) completionHandler;
- (void) dispose;
- (void) addText:(nonnull NSString*) text;
- (void) addImage:(nonnull UIImage*) image;
- (void) addMedia:(nonnull NSURL*) url;
- (void) commit;
@end


@interface NSSavePayload : NSObject <NSPayload>
- (instancetype) initWithAlbum:(nullable NSString*) album andCompletionHandler:(nullable CompletionHandler) completionHandler;
- (void) dispose;
- (void) addImage:(nonnull UIImage*) image;
- (void) addMedia:(nonnull NSURL*) url;
- (void) commit;
@end
