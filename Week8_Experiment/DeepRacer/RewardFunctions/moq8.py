import math

GEER_3=4.0
GEAR_2=2.67
GEAR_1=1.33
APRX_ZERO = 1e-3
MAX_STEERING_ANGLE=30
AT_WAYPOINT_REWARD= 2

def is_near_center(track_width, distance_from_center):
    '''
    This function encourages the car to stay in the middle of the road
    '''
    # Calculate 3 markers that are at varying distances away from the center line
    marker_1 = 0.1 * track_width
    marker_2 = 0.25 * track_width
    marker_3 = 0.5 * track_width
    
    # Give higher reward if the car is closer to center line and vice versa
    if distance_from_center <= marker_1:
        reward = 1.0
    elif distance_from_center <= marker_2:
        reward = 0.5
    elif distance_from_center <= marker_3:
        reward = 0.1
    else:
        reward = APRX_ZERO  # likely crashed/ close to off track

    return reward

def has_correct_heading(prev_point, next_point, heading):
	# Calculate the direction in radius, arctan2(dy, dx), the result is (-pi, pi) in radians
	track_direction = math.atan2(next_point[1] - prev_point[1], next_point[0] - prev_point[0]) 
	# Convert to degree
	track_direction = math.degrees(track_direction)

	# Calculate the difference between the track direction and the heading direction of the car
	direction_diff = abs(track_direction - heading)

	# Penalize the reward if the difference is too large
	DIRECTION_THRESHOLD = 10.0
	if direction_diff > DIRECTION_THRESHOLD:
		return 0.5

	return 1

def next_curve(waypoints, closest_waypoints):
    (x1, y1) = waypoints[closest_waypoints[0]]
    (x2, y2) = waypoints[closest_waypoints[1]]

    delta_y = y2-y1
    delta_x = max(x2-x1, APRX_ZERO)
    slope = delta_y/delta_x 
    return slope

def is_going_fast_enough(slope, speed):
    slope = abs(slope)
    
    if slope < 1:
        if speed > GEAR_2:
            return 1        
        else:
            return 0
    else:
        if speed < GEAR_1:
            return 1
        else:
            return 0

def reward_function(params):
    '''
    Reward based on multiple requires
    '''

    # Read input parameters
    all_wheels_on_track = params['all_wheels_on_track']
    track_width = params['track_width']
    distance_from_center = params['distance_from_center']
    is_left_of_center = params['is_left_of_center']
    heading = params['heading']
    progress = params['progress']
    steps = params['steps']
    speed = params['speed']
    steering_angle = params['steering_angle']
    waypoints = params['waypoints']
    closest_waypoints = params['closest_waypoints']
    x = params['x']
    y = params['y']

    # Determine the score for this run
    reward = 1

    # 1. Is the car on the road, this kills simulation so give HUGE penalty
    if all_wheels_on_track == False:
        return float(-5)

    # 2. The car should be near the center of the road
    reward += is_near_center(track_width=track_width, distance_from_center=distance_from_center)
    
    # 3. It should be pointing in the correct direction
    reward += has_correct_heading(
        prev_point=waypoints[closest_waypoints[0]],
        next_point=waypoints[closest_waypoints[1]],
        heading = heading)

    # 4. Are we going a desirable speed
    slope = next_curve(waypoints, closest_waypoints)
    reward += is_going_fast_enough(slope, speed)

    # Return the net score
    return float(reward)