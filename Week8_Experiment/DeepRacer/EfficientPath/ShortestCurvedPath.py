'''
This is based on https://stackoverflow.com/questions/28269379/curve-curvature-in-numpy
'''
import numpy as np

def get_track_curvature(waypoints):
  a = np.array(waypoints)
  dx_dt = np.gradient(a[:, 0])
  dy_dt = np.gradient(a[:, 1])
  velocity = np.array([ [dx_dt[i], dy_dt[i]] for i in range(dx_dt.size)])
  ds_dt = np.sqrt(dx_dt * dx_dt + dy_dt * dy_dt)
  tangent = np.array([1/ds_dt] * 2).transpose() * velocity

  tangent_x = tangent[:, 0]
  tangent_y = tangent[:, 1]

  deriv_tangent_x = np.gradient(tangent_x)
  deriv_tangent_y = np.gradient(tangent_y)

  dT_dt = np.array([ [deriv_tangent_x[i], deriv_tangent_y[i]] for i in range(deriv_tangent_x.size)])

  length_dT_dt = np.sqrt(deriv_tangent_x * deriv_tangent_x + deriv_tangent_y * deriv_tangent_y)

  normal = np.array([1/length_dT_dt] * 2).transpose() * dT_dt
  d2s_dt2 = np.gradient(ds_dt)
  d2x_dt2 = np.gradient(dx_dt)
  d2y_dt2 = np.gradient(dy_dt)

  curvature = np.abs(d2x_dt2 * dy_dt - dx_dt * d2y_dt2) / (dx_dt * dx_dt + dy_dt * dy_dt)**1.5
  t_component = np.array([d2s_dt2] * 2).transpose()
  n_component = np.array([curvature * ds_dt * ds_dt] * 2).transpose()

  acceleration = t_component * tangent + n_component * normal
  return (curvature, acceleration)

waypoints = [
  [2.5, 0.75],
  [3.33, 0.75],
  [4.17, 0.75],
  [5.0, 0.75],
  [5.83, 0.75],
  [6.67, 0.75],
  [7.5, 0.75],
  [8.33, 0.75],
  [9.17, 0.75],
  [9.75, 0.94],
  [10.00, 1.5],
  [10.00, 1.875],
  [9.92, 2.125],
  [9.58, 2.375],
  [9.17, 2.75],
  [8.33, 2.5],
  [7.5, 2.5],
  [7.08, 2.56],
  [6.67, 2.625],
  [5.83, 3.44],
  [5.0, 4.375],
  [4.67, 4.69],
  [4.33, 4.875],
  [4.0, 5.0],
  [3.33, 5.0],
  [2.5, 4.95],
  [2.08, 4.94],
  [1.67, 4.875],
  [1.33, 4.69],
  [0.92, 4.06],
  [1.17, 3.185],
  [1.5, 1.94],
  [1.6, 1.5],
  [1.83, 1.125],
  [2.17, 0.885]]

(curvature, acceleration) = get_track_curvature(waypoints)
print(curvature)