import math

MAX_SPEED=8.0
PENALIZE_ACTION = 1e-3
MAX_STEERING_ANGLE=30

def is_near_center(track_width, distance_from_center):
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
        reward = PENALIZE_ACTION  # likely crashed/ close to off track

    return reward

def has_correct_heading(prev_point, next_point, heading):
    # Initialize the reward with typical value 
	reward = 1.0

	# Calculate the direction in radius, arctan2(dy, dx), the result is (-pi, pi) in radians
	track_direction = math.atan2(next_point[1] - prev_point[1], next_point[0] - prev_point[0]) 
	# Convert to degree
	track_direction = math.degrees(track_direction)

	# Calculate the difference between the track direction and the heading direction of the car
	direction_diff = abs(track_direction - heading)

	# Penalize the reward if the difference is too large
	DIRECTION_THRESHOLD = 10.0
	if direction_diff > DIRECTION_THRESHOLD:
		reward *= 0.5

	return reward

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

    # 1. The car should be near the center of the road
    reward *= is_near_center(track_width=track_width, distance_from_center=distance_from_center)
    
    # 2. It should be pointing in the correct direction
    reward *= has_correct_heading(
        prev_point=waypoints[closest_waypoints[0]],
        next_point=waypoints[closest_waypoints[1]],
        heading = heading)
    
    # Return the net score
    return float(reward)