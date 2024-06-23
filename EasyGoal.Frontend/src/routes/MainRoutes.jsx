import { lazy } from 'react';

// project import
import Loadable from 'components/Loadable';
import Dashboard from 'layout/Dashboard';

const Color = Loadable(lazy(() => import('pages/component-overview/color')));
const Typography = Loadable(lazy(() => import('pages/component-overview/typography')));
const Shadow = Loadable(lazy(() => import('pages/component-overview/shadows')));
const DashboardDefault = Loadable(lazy(() => import('pages/dashboard/index')));

// render - sample page
const SamplePage = Loadable(lazy(() => import('pages/extra-pages/sample-page')));

// ==============================|| MAIN ROUTING ||============================== //

const MainRoutes = {
  path: 'app',
  element: <Dashboard />,
  children: [
    {
      path: '',
      element: <DashboardDefault />
    },
    {
      path: 'goals',
      element: <DashboardDefault />
    },
    {
      path: 'goals',
      children: [
        {
          path: ':goalId',
          element: <DashboardDefault />
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
