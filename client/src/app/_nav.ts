import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    name: 'Matches',
    url: '#',
    icon: 'cui-people'
  },
  {
    name: 'Lists',
    url: '#',
    icon: 'cui-list'
  },
  {
    name: 'Messages',
    url: '#',
    icon: 'cui-note'
  }
];
