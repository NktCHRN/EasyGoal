// material-ui
import Grid from '@mui/material/Grid';
import Pagination from '@mui/material/Pagination';
import Box from '@mui/material/Box';

// project import
import AnalyticEcommerce from 'components/cards/statistics/AnalyticEcommerce';
import Search from './SearchGoals'


const perPageCount = 12;
let page = 1;

export default function UserGoals() {
  return (
    <Grid container rowSpacing={4.5} columnSpacing={2.75}>
      <Grid item xs={12} sm={12} md={12} lg={12}>
      <Search></Search>
        </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce name="Become middle .NET developer" description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eget turpis vel odio iaculis interdum. Nunc mauris lorem, fringilla vitae aliquet luctus, congue in arcu. Curabitur non justo tempor, ullamcorper sapien id, sollicitudin ante. Vivamus vel arcu non metus tincidunt laoreet. Mauris tristique, eros at sagittis congue, libero risus pulvinar lacus, eget auctor sapien turpis et orci. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla non ligula quis nisl scelerisque tincidunt in at lacus. Vivamus a malesuada sapien. Aenean sit amet turpis est. Cras id dui tellus. " doneTasks="77" totalTasks="236" doneTasksPercentage={59.3} deadline="24.06.2024" extra="35,000" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Users" count="78,250" percentage={70.5} extra="8,900" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Order" count="18,800" percentage={27.4} isLoss color="warning" extra="1,943" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Sales" count="$35,078" percentage={27.4} isLoss color="warning" extra="$20,395" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Page Views" count="4,42,236" percentage={59.3} extra="35,000" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Users" count="78,250" percentage={70.5} extra="8,900" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Order" count="18,800" percentage={27.4} isLoss color="warning" extra="1,943" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Sales" count="$35,078" percentage={27.4} isLoss color="warning" extra="$20,395" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Page Views" count="4,42,236" percentage={59.3} extra="35,000" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Users" count="78,250" percentage={70.5} extra="8,900" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Order" count="18,800" percentage={27.4} isLoss color="warning" extra="1,943" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <AnalyticEcommerce title="Total Sales" count="$35,078" percentage={27.4} isLoss color="warning" extra="$20,395" />
      </Grid>
      <Grid item xs={12} sm={12} md={12} lg={12}>
      <Box display="flex" justifyContent="center">
        <Pagination count={10} variant="outlined" />
        </Box>
      </Grid>
    </Grid>
  );
}
