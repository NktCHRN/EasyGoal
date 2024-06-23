// assets
import { CalendarOutlined } from '@ant-design/icons';
import { CheckCircleOutlined } from '@ant-design/icons';

// icons
const icons = {
  CalendarOutlined,
  CheckCircleOutlined
};

const ToDo = {
  id: 'todo-group',
  title: 'ToDo',
  type: 'group',
  children: [
    {
      id: 'today',
      title: 'Today',
      type: 'item',
      url: '/app/today',
      icon: icons.CheckCircleOutlined,
      breadcrumbs: false
    },
    {
      id: 'calendar',
      title: 'Calendar',
      type: 'item',
      url: '/app/calendar',
      icon: icons.CalendarOutlined,
      breadcrumbs: false
    }
  ]
};

export default ToDo;
