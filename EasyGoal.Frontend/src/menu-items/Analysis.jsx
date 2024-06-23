import { LineChartOutlined } from '@ant-design/icons';

// icons
const icons = {
  LineChartOutlined
};

const Analysis = {
  id: 'analysis-group',
  title: 'Analysis',
  type: 'group',
  children: [
    {
      id: 'charts',
      title: 'Charts',
      type: 'item',
      url: '/app/charts',
      icon: icons.LineChartOutlined,
      breadcrumbs: false
    }
  ]
};

export default Analysis;
