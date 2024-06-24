import { lazy } from 'react';

// project import
import Loadable from 'components/Loadable';
import Dashboard from 'layout/Dashboard';

const Color = Loadable(lazy(() => import('pages/component-overview/color')));
const Typography = Loadable(lazy(() => import('pages/component-overview/charts')));
const Shadow = Loadable(lazy(() => import('pages/component-overview/shadows')));
const Goals = Loadable(lazy(() => import('pages/goals/index')));

// render - sample page
const SamplePage = Loadable(lazy(() => import('pages/extra-pages/sample-page')));

// ==============================|| MAIN ROUTING ||============================== //

const MainRoutes = {
  path: 'app',
  element: <Dashboard />,
  children: [
    {
      path: '',
      element: <Goals />
    },
    {
      path: 'goals',
      element: <Goals />
    },
    {
      path: 'goals',
      children: [
        {
          path: ':goalId',
          element: <Goals />
        }
      ]
    },
    {
      path: 'today',
      element: <Color />,
      children: [
        {
          path: ':date',
          element: <Color />,
        }
      ]
    },
    {
      path: 'calendar',
      element: <SamplePage />
    },
    {
      path: 'decision-helper',
      element: <Shadow />
    },
    {
      path: 'charts',
      element: <Typography />
    }
  ]
};

export default MainRoutes;
