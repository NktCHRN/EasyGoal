// assets
import { TrophyOutlined } from '@ant-design/icons';
import { ProjectOutlined } from '@ant-design/icons';
import { LineChartOutlined } from '@ant-design/icons';
import { CalendarOutlined } from '@ant-design/icons';
import { CheckCircleOutlined } from '@ant-design/icons';

// icons
const icons = {
  TrophyOutlined,
  ProjectOutlined,
  LineChartOutlined,
  CalendarOutlined,
  CheckCircleOutlined
};

const Goals = {
  id: 'goals-group',
  title: 'Goals',
  type: 'group',
  children: [
    {
      id: 'goals',
      title: 'Goals',
      type: 'item',
      url: '/app/goals',
      icon: icons.TrophyOutlined,
      breadcrumbs: false
    },
    {
      id: 'decision-helper',
      title: 'Decision helper',
      type: 'item',
      url: '/app/decision-helper',
      icon: icons.ProjectOutlined,
      breadcrumbs: false
    }
  ]
};

export default Goals;
